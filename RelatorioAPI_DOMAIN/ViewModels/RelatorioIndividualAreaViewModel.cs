using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioAPI_DOMAIN.ViewModels
{
    public class RelatorioIndividualAreaViewModel
    {
        //CLIE. ATUAL
        public int QTD_CLIENTE_ATUAL { get; set; }

        //Q.ANTER
        public int QTD_CLIENTE_MES_ANT { get; set; }

        //DESLIGOU
        public int DESLIGAMENTOS { get; set; }

        //INSTALOU
        public int NOVAS_INSTALACOES { get; set; }

        //MÊS
        public string MES_ATUAL { get; set; }

        //C.PROX. MES
        public int QTD_CLIENTE_PROXIMO_MES { get; set; }

    }
}
