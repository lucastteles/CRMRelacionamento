using CRMRelacionamento.Domain.Enidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> ObterClientes();
        Task<Cliente> ObterPorId(Guid id);
        Task<Cliente> AdicionarCliente(Cliente cliente);
        Task<Cliente> Atualizar(Cliente cliente);
        Task<Cliente> Remover(Cliente cliente); 
    }
}
