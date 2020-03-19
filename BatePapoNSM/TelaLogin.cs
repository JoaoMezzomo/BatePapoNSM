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
    public partial class TelaLogin : Form
    {
        TelaLoginCadastro cadastro = new TelaLoginCadastro();
        TelaConfigServidor config = new TelaConfigServidor();


        bool enter = true;
        string servidor = "";
        public TelaLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            enter = true;
            servidor = config.BuscarEndereco();
        }

        private void EfetuarLogin() 
        {
            if (string.IsNullOrEmpty(txtLogin.Text))
            {
                MessageBox.Show("O campo de usuário é de preenchimento obrigatório.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("O campo de senha é de preenchimento obrigatório.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Login.ValidarLogin(txtLogin.Text, txtSenha.Text, servidor) == true)
            {
                TelaConversa conversa = new TelaConversa(txtLogin.Text, this);
                conversa.Show();
                txtLogin.Clear();
                txtSenha.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos", "Falha no login", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            EfetuarLogin();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            enter = !enter;

            if (enter == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    EfetuarLogin();
                }
            }
        }

        private void linkCadastro_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            cadastro.ShowDialog();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            config.ShowDialog();
        }

        private void txtLogin_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogin.Text))
            {
                txtLogin.Text = txtLogin.Text.Replace(" ", "");
                txtLogin.Text = txtLogin.Text.ToLower();
                txtLogin.SelectionStart = txtLogin.Text.Length;
            }
        }

        private void linkEsqueciSenha_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Entre em contato com o administrador ou equipe suporte para realizar o cadastro de uma nova senha ou login.", "Esqueceu a senha ou login?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
