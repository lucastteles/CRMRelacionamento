using CRMRelacionamento.Domain.Enidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Domain.Interfaces 
{ 
    public interface IFornecedorRepository
    { 
        Task<IEnumerable<Fornecedor>> ObterFornecedores();
        Task<Fornecedor> ObterFornecedorPorId(Guid id); 
        Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor);
        Task<Fornecedor> Atualizar(Fornecedor fornecedor);
        Task<Fornecedor> Remover(Fornecedor fornecedor);
    }
}
