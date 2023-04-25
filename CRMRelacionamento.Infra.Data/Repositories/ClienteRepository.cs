using CRMRelacionamento.Domain.Enidades;
using CRMRelacionamento.Domain.Interfaces;
using CRMRelacionamento.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Infra.Data.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        ApplicationDbContext _clienteContext;

        public ClienteRepository(ApplicationDbContext context)
        {
            _clienteContext = context;
        }

        public async Task<Cliente> AdicionarCliente(Cliente cliente)
        {
            _clienteContext.Add(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<Cliente> Atualizar(Cliente cliente)
        {
            _clienteContext.Update(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }

        public async Task<IEnumerable<Cliente>> ObterClientes()
        {
            return await _clienteContext.Cliente.ToListAsync();
        }

        public async Task<Cliente> ObterPorId(Guid id)
        {
            return await _clienteContext.Cliente.FindAsync(id);
        }

        public async Task<Cliente> Remover(Cliente cliente)
        {
            _clienteContext.Remove(cliente);
            await _clienteContext.SaveChangesAsync();
            return cliente;
        }
    }
}
