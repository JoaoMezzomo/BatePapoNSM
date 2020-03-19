using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatePapoNSM
{
    class Status
    {
        public string StatusAtual(int index) 
        {
            string retorno = "";
            switch (index)
            {
                case 0:
                    retorno = "Offline";
                    break;
                case 1:
                    retorno = "Online";
                    break;
                case 2:
                    retorno = "Ausente";
                    break;
            }

            return retorno;
        }
    }
}
