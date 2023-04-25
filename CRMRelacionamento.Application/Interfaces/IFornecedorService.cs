using CRMRelacionamento.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Application.Interfaces
{ 
    public interface IFornecedorService
    {
        Task<IEnumerable<FornecedorDTO>> ObterFornecedor();
        Task<FornecedorDTO> ObterFornecedorPorId(Guid id);
        Task AdicionarFornecedor(FornecedorDTO clienteDTO);
        Task AtualizarFornecedor(FornecedorDTO clienteDTO);
        Task RemoverFornecedor(Guid id);
    }
}
