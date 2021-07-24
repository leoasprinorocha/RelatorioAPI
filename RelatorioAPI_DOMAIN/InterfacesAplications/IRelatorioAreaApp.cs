using RelatorioAPI_DOMAIN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioAPI_DOMAIN.InterfacesAplications
{
    public interface IRelatorioAreaApp
    {
        Task<byte[]> RelaotorioIndividualArea(RelatorioIndividualAreaViewModel listaPreenchida);

    }
}
