using System;
using System.IO;
using System.Net;
using Api.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CEPController : Controller
    {
        [Authorize]
        [HttpPost]
        public ActionResult retornarEndereco([FromBody] CEPDto CEPDto)
        {
            try
            {
                string server = "https://viacep.com.br/";
                string relativePath = "ws/" + CEPDto.CEP + "/json/";

                Uri serverUri = new Uri(server);
                Uri relativeUri = new Uri(relativePath, UriKind.Relative);

                Uri fullUri = new Uri(serverUri, relativeUri);

                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(fullUri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(dataStream);
                    string responseFromServer = reader.ReadToEnd();

                    response.Close();

                    return Ok(responseFromServer);
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
