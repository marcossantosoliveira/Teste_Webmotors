using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Teste_WebMotors.Application.ViewModels;
using Teste_WebMotors.Core.Interfaces.Repository;

namespace Teste_WebMotors.Infrastructure.Persistence.CrossCutting
{
    public class MakeCrossCutting : IMakeCrossCutting
    {
        public async Task<IEnumerable<Marca>> GetAll()
        {
            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make";
            var listaMarcas = new List<Marca>();


            using (HttpClient client = new HttpClient())
            {
                var resposta = await client.GetStringAsync(url);

                listaMarcas = JsonConvert.DeserializeObject<List<Marca>>(resposta);
            }

            return listaMarcas;
        }
    }
}
