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
    public class ModelCrossCutting : IModelCrossCutting
    {
        public async Task<IEnumerable<Modelo>> GetModelByIdMake(int id)
        {
            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID=" + id;
            var listaModelos = new List<Modelo>();


            using (HttpClient client = new HttpClient())
            {
                var resposta = await client.GetStringAsync(url);

                listaModelos = JsonConvert.DeserializeObject<List<Modelo>>(resposta);
            }

            return listaModelos;
        }
    }
}
