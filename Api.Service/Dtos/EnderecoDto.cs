namespace Api.Service.Dtos
{
    public class EnderecoDto
    {
        public string CEP { get; set; }

        public string Logradouro { get; set; }

        public string complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string IBGE { get; set; }
        public string GIA { get; set; }
        public string DDD { get; set; }
        public string SIAFI { get; set; }
    }
}
