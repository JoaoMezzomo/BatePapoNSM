using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BatePapoNSM
{
    public partial class TelaLoginCadastro : Form
    {
        TelaConfigServidor config = new TelaConfigServidor();
        bool enter = true;
        string servidor = "";

        public TelaLoginCadastro()
        {
            InitializeComponent();
            servidor = config.BuscarEndereco();
        }

        private void TelaLoginCadastro_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text))
            {
                txtLogin.Text = txtLogin.Text.Replace(" ", "");
                txtLogin.Text = txtLogin.Text.ToLower();
                txtLogin.SelectionStart = txtLogin.Text.Length;

                if (Login.VerificarLoginExistente(txtLogin.Text, servidor) == true)
                {
                    labelDisponivel.Text = "Login disponível";
                    labelDisponivel.ForeColor = System.Drawing.Color.Lime;
                    labelDisponivel.Visible = true;
                }
                else
                {
                    labelDisponivel.Text = "Login indisponível";
                    labelDisponivel.ForeColor = System.Drawing.Color.Red;
                    labelDisponivel.Visible = true;
                }
            }
            else
            {
                labelDisponivel.Visible = false;
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            EfetuarCadastro();
        }

        private void EfetuarCadastro() 
        {
            if ((string.IsNullOrEmpty(txtLogin.Text)) || (string.IsNullOrEmpty(txtSenha.Text)) || (string.IsNullOrEmpty(txtRedSenha.Text)) || (string.IsNullOrEmpty(txtNome.Text)) || (string.IsNullOrEmpty(txtEmail.Text)))
            {
                MessageBox.Show("Todos os campos são de preenchimento obrigatório.\n\nPreencha todos para poder realizar seu cadastro.", "Campos Obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Login.VerificarLoginExistente(txtLogin.Text, servidor) == false)
            {
                MessageBox.Show("O Login que você escolheu já encontra-se em uso.\n\nEscolha outro Login para poder realizar seu cadastro.", "Login Indisponível", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (txtSenha.Text != txtRedSenha.Text)
            {
                MessageBox.Show("As senhas dos campos \"Senha\" e \"Repita a Senha\" estão diferentes.\n\nDigite novamente sua senha nesses campos para poder realizar seu cadastro.", "Senhas diferentes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if ((!txtEmail.Text.Contains('@')) || (!txtEmail.Text.Contains('.')))
            {
                MessageBox.Show("O E-mail informado é inválido.\n\nDigite um E-mail válido para poder realizar seu cadastro.", "E-mail Inválido", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Login.CadastrarUsuario(txtLogin.Text, txtSenha.Text, txtNome.Text, txtEmail.Text, servidor);

            MessageBox.Show("Cadastro para o Login: " + txtLogin.Text + " realizado com sucesso!", "Cadastro Realizado", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtLogin.Clear();
            txtSenha.Clear();
            txtRedSenha.Clear();
            txtNome.Clear();
            txtEmail.Clear();

            this.Hide();
        }

        private void TelaLoginCadastro_KeyUp(object sender, KeyEventArgs e)
        {
            enter = !enter;

            if (enter == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EfetuarCadastro();
                }
            }
        }
    }
}
