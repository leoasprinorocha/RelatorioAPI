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
        public async Task<HttpResponseMessage> RelatorioIndividualArea(RelatorioIndividualAreaViewModel parametros)
        {
            var file = await _relatorioAreaApp.RelaotorioIndividualArea(parametros);

            HttpResponseMessage response = new HttpResponseMessage() { StatusCode = HttpStatusCode.OK };

            

            response.Content = new ByteArrayContent(file);

            response.Content.Headers.ContentLength = file.Length;

            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");

            CookieHeaderValue cookie = new CookieHeaderValue("fileDownload", "true")
            {
                Path = "/"
            };

            response.Headers.AddCookies(new CookieHeaderValue[] { cookie });

            return response;
        }

    }
}
