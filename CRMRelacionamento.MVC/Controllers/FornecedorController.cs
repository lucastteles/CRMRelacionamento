using CRMRelacionamento.Application.DTOs;
using CRMRelacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRMRelacionamento.MVC.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly IFornecedorService _fornecedorService;

        public FornecedorController(IFornecedorService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var fornecedor = await _fornecedorService.ObterFornecedor();
            return View(fornecedor);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.AdicionarFornecedor(fornecedorDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(fornecedorDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid id)
        {

            var fornecedorDTO = await _fornecedorService.ObterFornecedorPorId(id);

            if (fornecedorDTO == null) return NotFound();
            //var cliente = await _clienteService.ObterClientes();

            return View(fornecedorDTO);

        }

        [HttpPost()]
        public async Task<IActionResult> Edit(FornecedorDTO fornecedorDTO)
        {
            if (ModelState.IsValid)
            {
                await _fornecedorService.AtualizarFornecedor(fornecedorDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedorDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid id)
        {

            var fornecedorDTO = await _fornecedorService.ObterFornecedorPorId(id);

            if (fornecedorDTO == null) return NotFound();

            return View(fornecedorDTO);

        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _fornecedorService.RemoverFornecedor(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(Guid id)
        {


            var fornecedorDTO = await _fornecedorService.ObterFornecedorPorId(id);

            if (fornecedorDTO == null) return NotFound();

            return View(fornecedorDTO);

        }
    }
}

