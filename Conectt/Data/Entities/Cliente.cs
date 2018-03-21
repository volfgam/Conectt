using System;

namespace Conectt.Data.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Empresa { get; set; }
        public string TelefoneComercialDdd { get; set; }
        public string TelefoneComercial { get; set; }
        public string CelularDdd { get; set; }
        public string Celular { get; set; }
        public int Idade { get; set; }
    }
}
