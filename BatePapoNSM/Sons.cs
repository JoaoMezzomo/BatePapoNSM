using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatePapoNSM
{
    class Sons
    {
        TelaConfigServidor config = new TelaConfigServidor();

        public string BuscarSom(int index) 
        {
            string retorno = "";
            string servidor = "";
            servidor = config.BuscarEndereco();

            switch (index)
            {
                case 1:
                    //NOTIFICAÇÃO
                    retorno = servidor + "\\SONS\\NOTIFICACAO.wav";
                    break;
            }

            return retorno;
        }
    }
}
