using CRMRelacionamento.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Domain.Enidades
{
    public sealed class Fornecedor : Entity
    {
        public string Nome { get; private set; }

        public string Endereco { get; private set; }

        public string Telefone { get; private set; }

        public string Email { get; private set; }


        public Fornecedor(string nome, string endereco, string telefone, string email)
        {
            ValidateDomain(nome, endereco, telefone, email);
        }

        public void Update(string nome, string endereco, string telefone, string email)
        {
            ValidateDomain(nome, endereco, telefone, email);
        }


        private void ValidateDomain(string nome, string endereco, string telefone, string email)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. Nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3, "Nome inválido, minimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "Endereço inválido. Endereço é obrigatório");

            DomainExceptionValidation.When(endereco.Length < 10, "Endereço inválido, minimo 10 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone inválido. Telefone é obrigatório");

            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "Email inválido. Email é obrigatório");



            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
        }
    }
}
