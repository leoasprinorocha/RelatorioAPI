using Microsoft.AspNetCore.Mvc;
using RelatorioAPI_DOMAIN.InterfacesAplications;
using RelatorioAPI_DOMAIN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace RelatorioAPI.Controllers
{
    
    [ApiController]
    [Route("RelatorioGeral")]
    public class RelatorioGeralController : ControllerBase
    {
        private readonly IRelatorioAreaApp _relatorioAreaApp;

        public RelatorioGeralController(IRelatorioAreaApp relatorioAreaApp)
        {
            _relatorioAreaApp = relatorioAreaApp;

        }

        [Route("RelatorioIndividualArea")]
        [HttpPost]
        public async Task<FileContentResult> RelatorioIndividualArea(RelatorioIndividualAreaViewModel parametros)
        {
            var file = await _relatorioAreaApp.RelaotorioIndividualArea(parametros);

            var retorno = File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            return retorno;
        }

    }
}
