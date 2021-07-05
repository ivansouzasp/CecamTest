using System;
using System.ComponentModel.DataAnnotations;

namespace CECAM.Domain.Dtos
{
    public class ClienteDto
    {
        public int Codigo { get; set; }
        [Required]
        public string RazaoSocial { get; set; }
        [Required]
        public string CNPJ { get; set; }
        [Required]
        public DateTime DataCadastro { get; set; }
    }
}
