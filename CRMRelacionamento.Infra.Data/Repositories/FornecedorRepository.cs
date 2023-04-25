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
    public class FornecedorRepository : IFornecedorRepository
    {
        ApplicationDbContext _fornecedorContext;

        public FornecedorRepository(ApplicationDbContext context)
        {
            _fornecedorContext = context;
        }

        public async Task<Fornecedor> AdicionarFornecedor(Fornecedor fornecedor)
        {
            _fornecedorContext.Add(fornecedor);
            await _fornecedorContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor> Atualizar(Fornecedor fornecedor)
        {
            _fornecedorContext.Update(fornecedor);
            await _fornecedorContext.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<IEnumerable<Fornecedor>> ObterFornecedores()
        {
            return await _fornecedorContext.Fornecedor.ToListAsync();
        }

        public async Task<Fornecedor> ObterFornecedorPorId(Guid id)
        {
            return await _fornecedorContext.Fornecedor.FindAsync(id);
        }

        public async Task<Fornecedor> Remover(Fornecedor fornecedor)
        {
            _fornecedorContext.Remove(fornecedor);
            await _fornecedorContext.SaveChangesAsync();
            return fornecedor;
        }
    }
}
