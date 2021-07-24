
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using OfficeOpenXml;
using RelatorioAPI_DOMAIN.InterfacesAplications;
using RelatorioAPI_DOMAIN.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelatorioAPI_DOMAIN.Aplications
{
    public class RelatorioAreaApp : IRelatorioAreaApp
    {
        private readonly IHostEnvironment _env;

        public RelatorioAreaApp(IHostEnvironment env)
        {
            _env = env;
        }


        public async Task<byte[]> RelaotorioIndividualArea(RelatorioIndividualAreaViewModel listaPreenchida)
        {


            try
            {
                var path = Path.Combine("ModelosExcel","RelatorioAreaExcel.xlsx");

                byte[] byteArray = File.ReadAllBytes(path);

                using (MemoryStream stream = new MemoryStream(byteArray))
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                    using (ExcelPackage excelPackage = new ExcelPackage(stream))
                    {

                        foreach (ExcelWorksheet worksheet in excelPackage.Workbook.Worksheets)
                        {

                            worksheet.Cells.AutoFitColumns();
                        }

                        byteArray = excelPackage.GetAsByteArray();
                    }

                    return byteArray;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
