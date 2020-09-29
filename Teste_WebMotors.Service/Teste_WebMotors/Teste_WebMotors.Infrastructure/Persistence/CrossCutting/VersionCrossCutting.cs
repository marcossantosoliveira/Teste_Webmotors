using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class VersionCrossCutting : IVersionCrossCutting
    {
        public async Task<IEnumerable<Versao>> GetVersionByIdModel(int id)
        {
            string url = "http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID=" + id;
            var listaVersoes = new List<Versao>();

            using (HttpClient client = new HttpClient())
            {
                var resposta = await client.GetStringAsync(url);

                listaVersoes = JsonConvert.DeserializeObject<List<Versao>>(resposta);
            }

            return listaVersoes;
        }
    }
}
