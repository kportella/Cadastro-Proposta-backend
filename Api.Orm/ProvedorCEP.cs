using System;
using System.IO;
using System.Net;

namespace Api.Orm
{
    public class ProvedorCEP
    {
        public string BuscarCEP(string cep)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("https://viacep.com.br/ws/" + cep + "/json/");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                response.Close();

                return responseFromServer;
            }
        }
    }
}
