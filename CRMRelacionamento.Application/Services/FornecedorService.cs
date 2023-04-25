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
    public class FornecedorService : IFornecedorService
    {
        private IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;


        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<FornecedorDTO>> ObterFornecedor()
        {
            var fornecedorEntity = await _fornecedorRepository.ObterFornecedores();
            return _mapper.Map<IEnumerable<FornecedorDTO>>(fornecedorEntity);
        }

        public async Task<FornecedorDTO> ObterFornecedorPorId(Guid id)
        {
            var fornecedorEntity = await _fornecedorRepository.ObterFornecedorPorId(id);
            return _mapper.Map<FornecedorDTO>(fornecedorEntity);

        }

        public async Task AdicionarFornecedor(FornecedorDTO fornecedorDTO)
        {
            var fornecedorEntity = _mapper.Map<Fornecedor>(fornecedorDTO);
            await _fornecedorRepository.AdicionarFornecedor(fornecedorEntity);


        }

        public async Task AtualizarFornecedor(FornecedorDTO fornecedorDTO)
        {
            var fornecedorEntity = _mapper.Map<Fornecedor>(fornecedorDTO);
            await _fornecedorRepository.Atualizar(fornecedorEntity);
        }

        public async Task RemoverFornecedor(Guid id)
        {
            var fornecedorEntity = _fornecedorRepository.ObterFornecedorPorId(id).Result;
            await _fornecedorRepository.Remover(fornecedorEntity);
        }
    }
}
