using System;
namespace CECAM.Domain.Dtos
{
    public class ClienteDto
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
