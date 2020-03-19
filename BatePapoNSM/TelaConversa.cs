using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.IO;

namespace BatePapoNSM
{
    public partial class TelaConversa : Form
    {
        TelaConfigServidor config = new TelaConfigServidor();
        string servidor = "";
        string loginConversaAberta = "";
        string pathConversaAtualMeuLogin = "";
        string pathConversaAtualFulanoLogin = "";
        string pathMinhaNotificacoes = "";
        string pathFulanoNotificacoes = "";
        bool timerDeStatus = false;
        bool sair = false;
        bool sonsAtivado = true;
        Usuario usuario;
        List<Usuario> ListaDeContatos;
        Form telaLoginParametro;
        Status status = new Status();
        Criptografia criptografia = new Criptografia();
        Sons sons = new Sons();

        public TelaConversa(string loginParametro, Form telaLogin)
        {
            InitializeComponent();

            tabControl1.SelectedIndex = 1;
            servidor = config.BuscarEndereco();
            usuario = Login.CarregarInformacoesUsuario(loginParametro, servidor);
            telaLoginParametro = telaLogin;
            pathMinhaNotificacoes = servidor + "\\NOTIFICACAO\\" + criptografia.Encriptar(usuario.Login);
            CarregarContatos();
            Login.MudarStatus(usuario.Login, "1", servidor);
            usuario.Status = "1";
            txtNome.Text = usuario.Nome + " (" + status.StatusAtual(Convert.ToInt32(usuario.Status)) + ")";
            VerificarPastaNotificacao();
            CarregarPerfil();
            timerStatus.Enabled = true;
        }

        private void SalvarAlteracoesPerfil() 
        {
            bool retorno = false;

            if (!string.IsNullOrEmpty(txtRedSenhaPerfil.Text) && txtSenhaPerfil.Text != txtRedSenhaPerfil.Text)
            {
                MessageBox.Show("As senhas dos campos \"Senha\" e \"Repita a Senha\" estão diferentes.\n\nDigite novamente sua senha nesses campos para poder atualizar seus dados.", "Senhas diferentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            if ((string.IsNullOrEmpty(txtSenhaPerfil.Text)) || (string.IsNullOrEmpty(txtNomePerfil.Text)) || (string.IsNullOrEmpty(txtEmailPerfil.Text)))
            {
                MessageBox.Show("Campos de preenchimento obrigatório não estão preenchidos.\n\nPreencha os campos para poder atualizar seus dados.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((!txtEmailPerfil.Text.Contains('@')) || (!txtEmailPerfil.Text.Contains('.')))
            {
                MessageBox.Show("O E-mail informado é inválido.\n\nDigite um E-mail válido para poder atualizar seus dados.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            retorno = Login.SalvarAlteracoesUsuario(usuario.Login, txtSenhaPerfil.Text, txtNomePerfil.Text, txtEmailPerfil.Text, servidor);

            usuario = Login.CarregarInformacoesUsuario(usuario.Login, servidor);

            CarregarPerfil();

            if (retorno == true)
            {
                MessageBox.Show("Dados atualizados com sucesso.", "Dados atualizados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void CarregarPerfil() 
        {
            txtLoginPerfil.Text = usuario.Login;
            txtNomePerfil.Text = usuario.Nome;
            txtSenhaPerfil.Text = usuario.Senha;
            txtRedSenhaPerfil.Text = "";
            txtEmailPerfil.Text = usuario.Email;
        }

        private void TocarSom(int index)
        {
            string som = sons.BuscarSom(index);

            if (File.Exists(som) && sonsAtivado == true)
            {
                SoundPlayer player = new SoundPlayer(som);
                player.Play();
            }
        }

        private void EnviarNotificacao() 
        {
            VerificarFulanoPastaNotificacao();

            if (!File.Exists(pathFulanoNotificacoes + "\\" + criptografia.Encriptar(usuario.Login) + ".not"))
            {
                using (StreamWriter writer = File.AppendText(pathFulanoNotificacoes + "\\" + criptografia.Encriptar(usuario.Login) + ".not"))
                {
                    writer.WriteLine("");
                }
            }
        }

        private void EnviarNotificacaoArquivo()
        {
            VerificarFulanoPastaNotificacao();

            if (!File.Exists(pathFulanoNotificacoes + "\\" + criptografia.Encriptar(usuario.Login) + ".arq"))
            {
                using (StreamWriter writer = File.AppendText(pathFulanoNotificacoes + "\\" + criptografia.Encriptar(usuario.Login) + ".arq"))
                {
                    writer.WriteLine("");
                }
            }
        }

        private bool CarregarNotificacao(string login)
        {
            bool retorno = false;
            VerificarPastaNotificacao();
            login = criptografia.Encriptar(login);

            DirectoryInfo diretorio = new DirectoryInfo(pathMinhaNotificacoes);

            if (File.Exists(pathMinhaNotificacoes + "\\" + login + ".not"))
            {
                if (!File.ReadAllText(pathMinhaNotificacoes + "\\" + login + ".not").Contains("1"))
                {
                    using (StreamWriter writer = File.AppendText(pathMinhaNotificacoes + "\\" + login + ".not"))
                    {
                        writer.WriteLine("1");
                    }

                    TocarSom(1);
                }
                retorno = true;
            }
            else
            {
                retorno = false;
            }

            return retorno;
        }

        private void CarregarNotificacaoConversaAtual()
        {
            VerificarPastaNotificacao();

            DirectoryInfo diretorio = new DirectoryInfo(pathMinhaNotificacoes);

            FileInfo[] notificacoes = diretorio.GetFiles();

            foreach (FileInfo notificacao in notificacoes)
            {
                string nome = notificacao.Name.Replace(".not", "");

                if (nome == criptografia.Encriptar(loginConversaAberta))
                {
                    MostrarConversa();
                    notificacao.Delete();
                    richConversa.SelectionStart = richConversa.Text.Length;
                    richConversa.ScrollToCaret();
                }
            }
        }

        private void VerificarFulanoPastaNotificacao()
        {
            if (!Directory.Exists(pathFulanoNotificacoes))
            {
                Directory.CreateDirectory(pathFulanoNotificacoes);
            }
        }

        private void VerificarPastaNotificacao() 
        {
            if (!Directory.Exists(pathMinhaNotificacoes))
            {
                Directory.CreateDirectory(pathMinhaNotificacoes);
            }
        }

        private void CarregarContatos() 
        {
            List<Usuario> contatos =  Login.CarregarInformacoesContatos(servidor, usuario.Login);
            listContatos.Items.Clear();
            int quantidade = contatos.Count;
            int i = 0;
            ListViewItem[] lista = new ListViewItem[quantidade];
            
            foreach (var contato in contatos)
            {
                if (contato.Login != usuario.Login)
                {
                    lista[i] = new ListViewItem(new string[] { contato.Nome, status.StatusAtual(Convert.ToInt32(contato.Status)) }, -1);

                    if (CarregarNotificacao(contato.Login) == true)
                    {
                        lista[i].BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        lista[i].BackColor = Color.White;
                    }

                    listContatos.Items.AddRange(new ListViewItem[] { lista[i] });
                    i++;
                }
            }

            ListaDeContatos = contatos;
        }

        private void BuscarConversa(string meuLogin, string fulanoLogin) 
        {
            string pathDiretorioConversasMeuLogin = servidor + "\\CONVERSAS\\" + criptografia.Encriptar(meuLogin);
            string pathConversaMeuLogin = pathDiretorioConversasMeuLogin + "\\" + criptografia.Encriptar(fulanoLogin) + ".nsm";

            if (!Directory.Exists(pathDiretorioConversasMeuLogin))
            {
                Directory.CreateDirectory(pathDiretorioConversasMeuLogin);
            }

            pathConversaAtualMeuLogin = pathConversaMeuLogin;

            string pathDiretorioConversasFulanoLogin = servidor + "\\CONVERSAS\\" + criptografia.Encriptar(fulanoLogin);
            string pathConversaFulanoLogin = pathDiretorioConversasFulanoLogin + "\\" + criptografia.Encriptar(meuLogin) + ".nsm";

            if (!Directory.Exists(pathDiretorioConversasFulanoLogin))
            {
                Directory.CreateDirectory(pathDiretorioConversasFulanoLogin);
            }

            pathConversaAtualFulanoLogin = pathConversaFulanoLogin;
        }

        private void EnviarArquivo() 
        {
            if (openFileEnviarArquivo.ShowDialog() == DialogResult.OK)
            {
                string[] pathArquivos = openFileEnviarArquivo.FileNames;
                string diretorioFulano = servidor + "\\ARQUIVOS\\" + criptografia.Encriptar(loginConversaAberta) + "\\" + criptografia.Encriptar(usuario.Login);
                string mensagem = "Arquivo(s) enviado(s):\n\n";
                string arquivos = null;

                if (!Directory.Exists(diretorioFulano))
                {
                    Directory.CreateDirectory(diretorioFulano);
                }

                foreach (string pathArquivo in pathArquivos)
                {
                    FileInfo arquivo = new FileInfo(pathArquivo);

                    File.Copy(pathArquivo, diretorioFulano + "\\" + arquivo.Name, true);

                    mensagem += "- " + arquivo.Name + "\n";
                    arquivos += arquivo.Name + "|";
                }

                string conteudo = "Login: " + criptografia.Encriptar(usuario.Login) + Environment.NewLine +
                                  "Arquivos: " + criptografia.Encriptar(arquivos) + Environment.NewLine +
                                  "Data: " + criptografia.Encriptar(DateTime.Now.ToString()) + Environment.NewLine;

                using (StreamWriter writer1 = File.AppendText(pathConversaAtualMeuLogin))
                {
                    writer1.WriteAsync(conteudo);
                }

                using (StreamWriter writer2 = File.AppendText(pathConversaAtualFulanoLogin))
                {
                    writer2.WriteAsync(conteudo);
                }

                MessageBox.Show(mensagem, "Concluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EnviarConversa()
        {
            if (!string.IsNullOrEmpty(txbDigitacao.Text))
            {
                string conteudo = "Login: " + criptografia.Encriptar(usuario.Login) + Environment.NewLine +
                                  "Conversa: " + criptografia.Encriptar(txbDigitacao.Text) + Environment.NewLine +
                                  "Data: " + criptografia.Encriptar(DateTime.Now.ToString()) + Environment.NewLine;

                using (StreamWriter writer1 = File.AppendText(pathConversaAtualMeuLogin))
                {
                    writer1.WriteAsync(conteudo);
                }

                using (StreamWriter writer2 =  File.AppendText(pathConversaAtualFulanoLogin))
                {
                    writer2.WriteAsync(conteudo);
                }
            }
        }

        private void MostrarConversa() 
        {
            ListView.SelectedIndexCollection indice = listContatos.SelectedIndices;
            richConversa.Clear();
            int pontoInicial = 0;
            int pontoFinal = 0;
            string texto = "";
            bool minhaFala = false;

            if (File.Exists(pathConversaAtualMeuLogin))
            {
                string[] linhas = File.ReadAllLines(pathConversaAtualMeuLogin);

                foreach (string linha in linhas)
                {
                    if (!string.IsNullOrEmpty(linha))
                    {
                        if (linha.Contains("Login: " + criptografia.Encriptar(usuario.Login)))
                        {
                            minhaFala = true;
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText(usuario.Nome + ":\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.CornflowerBlue;
                            richConversa.SelectionFont = new Font("", 12.0f, FontStyle.Bold);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }

                        if (linha.Contains("Data: ") && minhaFala == true) 
                        {
                            texto = linha.Replace("Data: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText("(" + criptografia.Decriptar(texto) + ")\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.CornflowerBlue;
                            richConversa.SelectionFont = new Font("", 7.0f, FontStyle.Bold);
                            richConversa.SelectionAlignment = HorizontalAlignment.Right;
                        }

                        if (linha.Contains("Conversa: ") && minhaFala == true)
                        {
                            texto = linha.Replace("Conversa: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText(criptografia.Decriptar(texto) + "\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.White;
                            richConversa.SelectionFont = new Font("", 11.0f, FontStyle.Regular);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }

                        if (linha.Contains("Arquivos: ") && minhaFala == true)
                        {
                            texto = linha.Replace("Arquivos: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;

                            string[] files = criptografia.Decriptar(texto).Split('|');
                            richConversa.AppendText("Envio de Arquivos:\n");

                            foreach (string file in files)
                            {
                                richConversa.AppendText(file + "\n");
                            }

                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.White;
                            richConversa.SelectionFont = new Font("", 11.0f, FontStyle.Regular);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }

                        if (linha.Contains("Login: " + criptografia.Encriptar(loginConversaAberta)))
                        {
                            minhaFala = false;
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText(ListaDeContatos[Convert.ToInt32(indice[0])].Nome + ":\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.PowderBlue;
                            richConversa.SelectionFont = new Font("", 12.0f, FontStyle.Bold);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }

                        if (linha.Contains("Data: ") && minhaFala == false)
                        {
                            texto = linha.Replace("Data: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText("(" + criptografia.Decriptar(texto) + ")\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.PowderBlue;
                            richConversa.SelectionFont = new Font("", 7.0f, FontStyle.Bold);
                            richConversa.SelectionAlignment = HorizontalAlignment.Right;
                        }

                        if (linha.Contains("Conversa: ") && minhaFala == false)
                        {
                            texto = linha.Replace("Conversa: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;
                            richConversa.AppendText(criptografia.Decriptar(texto) + "\n");
                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.White;
                            richConversa.SelectionFont = new Font("", 11.0f, FontStyle.Regular);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }

                        if (linha.Contains("Arquivos: ") && minhaFala == false)
                        {
                            texto = linha.Replace("Arquivos: ", "").Replace("\r\n", "");
                            pontoInicial = richConversa.Text.Length;

                            string[] files = criptografia.Decriptar(texto).Split('|');
                            richConversa.AppendText("Envio de Arquivos:\n");

                            foreach (string file in files)
                            {
                                richConversa.AppendText(file + "\n");
                            }

                            pontoFinal = richConversa.Text.Length;

                            richConversa.Select(pontoInicial, pontoFinal);
                            richConversa.SelectionColor = Color.White;
                            richConversa.SelectionFont = new Font("", 11.0f, FontStyle.Regular);
                            richConversa.SelectionAlignment = HorizontalAlignment.Left;
                        }
                    }
                }
            }  
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txbDigitacao.Text))
            {
                if (txbDigitacao.Text[txbDigitacao.Text.Length - 1] == '\n' && txbDigitacao.Text[txbDigitacao.Text.Length - 2] == '\r')
                {
                    txbDigitacao.Text = txbDigitacao.Text.Remove(txbDigitacao.Text.Length - 2);
                }

                EnviarConversa();
                EnviarNotificacao();
                MostrarConversa();
                Control teste = new Control();
                txbDigitacao.SelectNextControl(teste, true, false, true, true);
                richConversa.SelectionStart = richConversa.Text.Length;
                richConversa.ScrollToCaret();
                richConversa.SelectNextControl(teste, true, true, true, true);
                txbDigitacao.Clear();
            }
        }

        private void TelaConversa_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && Control.ModifierKeys != Keys.Shift && btnEnviar.Enabled == true)
            {
                if (!string.IsNullOrEmpty(txbDigitacao.Text))
                {
                    if (txbDigitacao.Text[txbDigitacao.Text.Length - 1] == '\n' && txbDigitacao.Text[txbDigitacao.Text.Length - 2] == '\r')
                    {
                        txbDigitacao.Text = txbDigitacao.Text.Remove(txbDigitacao.Text.Length - 2);
                    }

                    EnviarConversa();
                    EnviarNotificacao();
                    MostrarConversa();
                    Control teste = new Control();
                    txbDigitacao.SelectNextControl(teste, true, false, true, true);
                    richConversa.SelectionStart = richConversa.Text.Length;
                    richConversa.ScrollToCaret();
                    richConversa.SelectNextControl(teste, true, true, true, true);
                    txbDigitacao.Clear();
                }
            }
        }

        private void TelaConversa_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sair == false)
            {
                if (MessageBox.Show("Tem certeza de que deseja sair do NSM?", "Deseja sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sair = true;
                    Login.MudarStatus(usuario.Login, "0", servidor);
                    telaLoginParametro.Show();
                    this.Close();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza de que deseja sair do NSM?", "Deseja sair?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                sair = true;
                Login.MudarStatus(usuario.Login, "0", servidor);
                telaLoginParametro.Show();
                this.Close();
            }
        }

        private void listContatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indice = listContatos.SelectedIndices;

            if (indice.Count != 0)
            {
                timerNotificacao.Enabled = true;

                if (timerDeStatus == false)
                { 
                    loginConversaAberta = ListaDeContatos[Convert.ToInt32(indice[0])].Login;
                    pathFulanoNotificacoes = servidor + "\\NOTIFICACAO\\" + criptografia.Encriptar(loginConversaAberta);
                    txtFulano.Text = ListaDeContatos[Convert.ToInt32(indice[0])].Nome + " (" + status.StatusAtual(Convert.ToInt32(ListaDeContatos[Convert.ToInt32(indice[0])].Status)) + ")";
                    BuscarConversa(usuario.Login, loginConversaAberta);
                    MostrarConversa();

                    if (CarregarNotificacao(ListaDeContatos[Convert.ToInt32(indice[0])].Login) == true)
                    {
                        File.Delete(pathMinhaNotificacoes + "\\" + criptografia.Encriptar(ListaDeContatos[Convert.ToInt32(indice[0])].Login) + ".not");
                    }

                    txbDigitacao.ReadOnly = false;
                    btnEnviar.Enabled = true;
                    btnEnviarArquivo.Enabled = true;
                    richConversa.SelectionStart = richConversa.Text.Length;
                    richConversa.ScrollToCaret();
                }
                else
                {
                    timerDeStatus = false;
                }
            }
            else
            {
                txbDigitacao.ReadOnly = true;
                btnEnviar.Enabled = false;
                btnEnviarArquivo.Enabled = false;
            }
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            Login.MudarStatus(usuario.Login, comboStatus.SelectedIndex.ToString(), servidor);
            usuario.Status = comboStatus.SelectedIndex.ToString();
            txtNome.Text = usuario.Nome + " (" + status.StatusAtual(Convert.ToInt32(usuario.Status)) + ")";
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            ListView.SelectedIndexCollection indice = listContatos.SelectedIndices;
            int quantidadeInicial = indice.Count;
            int index = 0;

            if (indice.Count != 0)
            {
                index = Convert.ToInt32(indice[0]);
            }

            List<Usuario> contatos = Login.CarregarInformacoesContatos(servidor, usuario.Login);
            listContatos.Items.Clear();
            int quantidade = contatos.Count;
            int i = 0;
            ListViewItem[] lista = new ListViewItem[quantidade];

            foreach (var contato in contatos)
            {
                if (contato.Login != usuario.Login)
                {
                    lista[i] = new ListViewItem(new string[] { contato.Nome, status.StatusAtual(Convert.ToInt32(contato.Status)) }, -1);

                    if (CarregarNotificacao(contato.Login) == true)
                    {
                        lista[i].BackColor = Color.DarkOrange;
                    }
                    else
                    {
                        lista[i].BackColor = Color.White;
                    }

                    listContatos.Items.Insert(i, lista[i]);
                    i++;
                }
            }

            ListaDeContatos.Clear();
            ListaDeContatos = contatos;

            if (quantidadeInicial != 0)
            {
                timerDeStatus = true;
                listContatos.Items[index].Focused = true;
                listContatos.Items[index].Selected = true;
            }
        }

        private void timerNotificacao_Tick(object sender, EventArgs e)
        {
            CarregarNotificacaoConversaAtual();
        }

        private void btnSons_Click(object sender, EventArgs e)
        {
            sonsAtivado = !sonsAtivado;

            if (sonsAtivado == true)
            {
                btnSons.Text = "🔊";
            }
            else
            {
                btnSons.Text = "🔈";
            }
        }

        private void btnSalvarPerfil_Click(object sender, EventArgs e)
        {
            SalvarAlteracoesPerfil();
        }

        private void btnCancelarPerfil_Click(object sender, EventArgs e)
        {
            CarregarPerfil();
        }

        private void btnEnviarArquivo_Click(object sender, EventArgs e)
        {
            EnviarArquivo();
            EnviarNotificacaoArquivo();
            MostrarConversa();
        }
    }
}
