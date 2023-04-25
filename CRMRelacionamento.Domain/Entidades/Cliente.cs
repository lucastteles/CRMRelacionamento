using CRMRelacionamento.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Domain.Enidades
{
    public sealed class Cliente : Entity
    { 
        
        public string Telefone { get; private set; }


        public Cliente(string telefone)
        {
            ValidateDomain(telefone);
        }

        public void Update(string telefone)
        {
            ValidateDomain(telefone);
        }

        private void ValidateDomain(string telefone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "Telefone inválido. Telefone é obrigatório");


            Telefone = telefone;
            
        }
    }
}
