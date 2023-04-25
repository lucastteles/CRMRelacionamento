using CRMRelacionamento.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDTO>> ObterClientes();
        Task<ClienteDTO> ObterPorId(Guid id);
        Task Adicionar(ClienteDTO clienteDTO);
        Task Atualizar(ClienteDTO clienteDTO);
        Task Remover(Guid id);
    }
}
