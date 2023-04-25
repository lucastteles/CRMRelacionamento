using AutoMapper;
using CRMRelacionamento.Application.DTOs;
using CRMRelacionamento.Application.Interfaces;
using CRMRelacionamento.Domain.Enidades;
using CRMRelacionamento.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRMRelacionamento.Application.Services
{
    public class ClienteService : IClienteService
    {
        private IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;


        public ClienteService(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClienteDTO>> ObterClientes()
        {
            var clienteEntity = await _clienteRepository.ObterClientes();
            return _mapper.Map<IEnumerable<ClienteDTO>>(clienteEntity);
        }

        public async Task<ClienteDTO> ObterPorId(Guid id)
        {
            var clienteEntity = await _clienteRepository.ObterPorId(id);
            return _mapper.Map<ClienteDTO>(clienteEntity);
        }

        public async Task Adicionar(ClienteDTO clienteDTO)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.AdicionarCliente(clienteEntity);
        }

        public async Task Atualizar(ClienteDTO clienteDTO)
        {
            var clienteEntity = _mapper.Map<Cliente>(clienteDTO);
            await _clienteRepository.Atualizar(clienteEntity);
        }

        public async Task Remover(Guid id)
        {
            var clienteEntity = _clienteRepository.ObterPorId(id).Result;
            await _clienteRepository.Remover(clienteEntity);
        }
    }
}
