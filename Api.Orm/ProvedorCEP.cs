using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Api.Orm
{
    public class ProvedorCEP
    {
        public async Task<string> BuscarCEP(IHttpClientFactory _clientFactory, string CEP)
        {
            var client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri("https://viacep.com.br");

            using (Stream dataStream = await client.GetStreamAsync($"/ws/{CEP}/json/"))
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                return responseFromServer;
            }
        }
    }
}
