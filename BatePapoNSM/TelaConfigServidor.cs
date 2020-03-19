using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace BatePapoNSM
{
    public partial class TelaConfigServidor : Form
    {
        //====Servidor===//
        // - \\DESKTOP-5RVBC8F\ServidorNSM
        // - \\192.168.0.29\ServidorNSM

        bool enter = true;
        public TelaConfigServidor()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SalvarEndereco();
        }

        private void SalvarEndereco() 
        {
            string pathArquivo = System.Environment.CurrentDirectory.ToString() + "\\Config.xml";
            Criptografia criptografia = new Criptografia();

            if (Directory.Exists(txtEndereco.Text))
            {
                XmlDocument arquivo = CarregarConfig();
                XmlNode nodeEndereco = arquivo.SelectSingleNode("config/endereco");
                nodeEndereco.InnerText = criptografia.Encriptar(txtEndereco.Text);
                arquivo.Save(pathArquivo);
                MessageBox.Show("Endereço do servidor salvo com sucesso!", "Endereço Salvo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
            }
            else
            {
                MessageBox.Show("Endereço do servidor não encontrado!", "Servidor Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        public string BuscarEndereco()
        {
            string retorno = null;
            Criptografia criptografia = new Criptografia();

            XmlDocument arquivo = CarregarConfig();
            XmlNode nodeEndereco = arquivo.SelectSingleNode("config/endereco");
            if (!string.IsNullOrEmpty(nodeEndereco.InnerText))
            {
                retorno = criptografia.Decriptar(nodeEndereco.InnerText);
            }

            if (!Directory.Exists(retorno))
            {
                MessageBox.Show("Endereço do servidor não encontrado!", "Servidor Não Encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                retorno = null;
            }

            return retorno;
        }

        public XmlDocument CarregarConfig() 
        {
            string pathArquivo = System.Environment.CurrentDirectory.ToString() + "\\Config.xml";
            XmlDocument arquivo = new XmlDocument();

            if (!File.Exists(pathArquivo))
            {
                using (FileStream fs = File.Create(pathArquivo))
                {
                    arquivo.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                    + "<config>"
                    + "<endereco></endereco>"
                    + "</config>"
                    );
                }
                arquivo.Save(pathArquivo);
            }
            else
            {
                arquivo.Load(pathArquivo);
            }

            return arquivo;
        }

        private void TelaConfigServidor_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void TelaConfigServidor_KeyUp(object sender, KeyEventArgs e)
        {
            enter = !enter;

            if (enter == false)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SalvarEndereco();
                }
            }
        }
    }
}
