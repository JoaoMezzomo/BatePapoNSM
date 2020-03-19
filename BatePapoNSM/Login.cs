using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace BatePapoNSM
{
    class Login
    {
        public static bool ValidarLogin(string login, string senha, string servidor) 
        {
            Criptografia criptografia = new Criptografia();
            bool retorno = false;
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();
            
            foreach (FileInfo usuario in usuarios)
            {
                XmlDocument arquivo = new XmlDocument();
                arquivo.Load(usuario.FullName);
               
                XmlNode nodeLogin = arquivo.SelectSingleNode("dados/login");
                XmlNode nodeSenha = arquivo.SelectSingleNode("dados/senha");

                if (criptografia.Decriptar(nodeLogin.InnerText) == login && criptografia.Decriptar(nodeSenha.InnerText) == senha)
                {
                    retorno = true;
                }
                
            }

            return retorno;
        }

        public static bool VerificarLoginExistente(string loginFuturo, string servidor) 
        {
            Criptografia criptografia = new Criptografia();
            bool retorno = true;
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();

            foreach (FileInfo usuario in usuarios)
            {
                XmlDocument arquivo = new XmlDocument();
                arquivo.Load(usuario.FullName);

                XmlNode nodeLogin = arquivo.SelectSingleNode("dados/login");

                if (criptografia.Decriptar(nodeLogin.InnerText) == loginFuturo)
                {
                    retorno = false;
                }

            }
            return retorno;
        }

        public static List<Usuario> CarregarInformacoesContatos(string servidor, string meuLogin)
        {
            Criptografia criptografia = new Criptografia();
            List<Usuario> usuariosList = new List<Usuario>();
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();

            foreach (FileInfo usuario1 in usuarios)
            {
                XmlDocument arquivo = new XmlDocument();
                arquivo.Load(usuario1.FullName);

                XmlNode nodeLogin = arquivo.SelectSingleNode("dados/login");
                XmlNode nodeNome = arquivo.SelectSingleNode("dados/nome");
                XmlNode nodeStatus = arquivo.SelectSingleNode("dados/status");

                Usuario usuario = new Usuario();
                usuario.Login = criptografia.Decriptar(nodeLogin.InnerText);
                usuario.Nome = criptografia.Decriptar(nodeNome.InnerText);
                usuario.Status = criptografia.Decriptar(nodeStatus.InnerText);

                if (usuario.Login != meuLogin)
                {
                    usuariosList.Add(usuario);
                }
            }
            return usuariosList;
        }

        public static Usuario CarregarInformacoesUsuario(string login, string servidor) 
        {
            Criptografia criptografia = new Criptografia();
            Usuario usuario = new Usuario();
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();

            foreach (FileInfo usuario1 in usuarios)
            {
                XmlDocument arquivo = new XmlDocument();
                arquivo.Load(usuario1.FullName);

                XmlNode nodeLogin = arquivo.SelectSingleNode("dados/login");
                
                if (criptografia.Decriptar(nodeLogin.InnerText) == login)
                {
                    XmlNode nodeSenha = arquivo.SelectSingleNode("dados/senha");
                    XmlNode nodeNome = arquivo.SelectSingleNode("dados/nome");
                    XmlNode nodeEmail = arquivo.SelectSingleNode("dados/email");
                    XmlNode nodeStatus = arquivo.SelectSingleNode("dados/status");

                    usuario.Login = criptografia.Decriptar(nodeLogin.InnerText);
                    usuario.Senha = criptografia.Decriptar(nodeSenha.InnerText);
                    usuario.Nome = criptografia.Decriptar(nodeNome.InnerText);
                    usuario.Email = criptografia.Decriptar(nodeEmail.InnerText);
                    usuario.Status = criptografia.Decriptar(nodeStatus.InnerText);
                }

            }
            return usuario;
        }

        public static void MudarStatus(string login, string status, string servidor)
        {
            Criptografia criptografia = new Criptografia();
            Usuario usuario = new Usuario();
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();

            foreach (FileInfo usuario1 in usuarios)
            {
                XmlDocument arquivo = new XmlDocument();
                arquivo.Load(usuario1.FullName);

                XmlNode nodeLogin = arquivo.SelectSingleNode("dados/login");
                XmlNode nodeStatus = arquivo.SelectSingleNode("dados/status");

                if (criptografia.Decriptar(nodeLogin.InnerText) == login)
                {
                    nodeStatus.InnerText = criptografia.Encriptar(status);
                    arquivo.Save(usuario1.FullName);
                }

            }
        }

        public static void CadastrarUsuario(string login, string senha, string nome, string email, string servidor) 
        {
            Criptografia criptografia = new Criptografia();
            string pathArquivo = servidor + "\\USUARIOS\\" + criptografia.Encriptar(login + DateTime.Now.ToString()) + ".xml";
            string pathDiretorioConversas = servidor + "\\CONVERSAS\\" + criptografia.Encriptar(login);
            string pathDiretorioNotificacao = servidor + "\\NOTIFICACAO\\" + criptografia.Encriptar(login);
            string pathDiretorioArquivos = servidor + "\\ARQUIVOS\\" + criptografia.Encriptar(login);
            XmlDocument arquivo = new XmlDocument();

            using (FileStream fs = File.Create(pathArquivo))
            {
                arquivo.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>"
                + "<dados>"
                + "<nome>" + criptografia.Encriptar(nome) + "</nome>"
                + "<email>" + criptografia.Encriptar(email) + "</email>"
                + "<login>" + criptografia.Encriptar(login) + "</login>"
                + "<senha>" + criptografia.Encriptar(senha) + "</senha>"
                + "<status>" + criptografia.Encriptar("0") + "</status>"
                + "</dados>"
                );
            }
            arquivo.Save(pathArquivo);

            if (!Directory.Exists(pathDiretorioConversas))
            {
                Directory.CreateDirectory(pathDiretorioConversas);
            }
            else
            {
                DirectoryInfo diretorioExistente = new DirectoryInfo(pathDiretorioConversas);
                FileInfo[] conversasAntigas = diretorioExistente.GetFiles();

                foreach (FileInfo conversa in conversasAntigas)
                {
                    File.Delete(conversa.FullName);
                }
            }

            if (!Directory.Exists(pathDiretorioNotificacao))
            {
                Directory.CreateDirectory(pathDiretorioNotificacao);
            }
            else
            {
                DirectoryInfo diretorioExistente = new DirectoryInfo(pathDiretorioNotificacao);
                FileInfo[] notificacoesAntigas = diretorioExistente.GetFiles();

                foreach (FileInfo notificacao in notificacoesAntigas)
                {
                    File.Delete(notificacao.FullName);
                }
            }

            if (!Directory.Exists(pathDiretorioArquivos))
            {
                Directory.CreateDirectory(pathDiretorioArquivos);
            }
            else
            {
                DirectoryInfo diretorioExistente = new DirectoryInfo(pathDiretorioArquivos);
                FileInfo[] arquivosAntigos = diretorioExistente.GetFiles();

                foreach (FileInfo arquivo1 in arquivosAntigos)
                {
                    File.Delete(arquivo1.FullName);
                }
            }
        }

        public static bool SalvarAlteracoesUsuario(string login, string senha, string nome, string email, string servidor)
        {
            Criptografia criptografia = new Criptografia();
            Usuario usuario = new Usuario();
            string pathUsuarios = servidor + "\\USUARIOS";
            DirectoryInfo diretorioUsuarios = new DirectoryInfo(pathUsuarios);
            FileInfo[] usuarios = diretorioUsuarios.GetFiles();
            bool retorno = false;

            foreach (FileInfo usuario1 in usuarios)
            {
                XmlDocument arquivo1 = new XmlDocument();
                arquivo1.Load(usuario1.FullName);

                XmlNode nodeLogin = arquivo1.SelectSingleNode("dados/login");
                XmlNode nodeSenha = arquivo1.SelectSingleNode("dados/senha");
                XmlNode nodeNome = arquivo1.SelectSingleNode("dados/nome");
                XmlNode nodeEmail = arquivo1.SelectSingleNode("dados/email");


                if (criptografia.Decriptar(nodeLogin.InnerText) == login)
                {
                    if (nodeSenha.InnerText != criptografia.Encriptar(senha))
                    {
                        retorno = true;
                        nodeSenha.InnerText = criptografia.Encriptar(senha);
                    }

                    if (nodeNome.InnerText != criptografia.Encriptar(nome))
                    {
                        retorno = true;
                        nodeNome.InnerText = criptografia.Encriptar(nome);
                    }

                    if (nodeEmail.InnerText != criptografia.Encriptar(email))
                    {
                        retorno = true;
                        nodeEmail.InnerText = criptografia.Encriptar(email);
                    }

                    arquivo1.Save(usuario1.FullName);
                }

            }

            return retorno;

        }
    }
}
