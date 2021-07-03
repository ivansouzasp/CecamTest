using System;

namespace CECAM.Entities
{
    public class Cliente
    {
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
