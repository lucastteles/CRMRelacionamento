using CRMRelacionamento.Application.DTOs;
using CRMRelacionamento.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CRMRelacionamento.MVC.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _clienteService.ObterClientes();
            return View(clientes);
        }

        [HttpGet()]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.Adicionar(clienteDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(clienteDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(Guid id)
        {

            var clienteDTO = await _clienteService.ObterPorId(id);

            if (clienteDTO == null) return NotFound();
            //var cliente = await _clienteService.ObterClientes();

            return View(clienteDTO);

        }

        [HttpPost()]
        public async Task<IActionResult> Edit(ClienteDTO clienteDTO)
        {
            if (ModelState.IsValid)
            {
                await _clienteService.Atualizar(clienteDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(clienteDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(Guid id)
        {

            var clienteDTO = await _clienteService.ObterPorId(id);

            if (clienteDTO == null) return NotFound();

            return View(clienteDTO);

        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _clienteService.Remover(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(Guid id)
        {


            var clienteDTO = await _clienteService.ObterPorId(id);

            if (clienteDTO == null) return NotFound();

            return View(clienteDTO);

        }
    }
}

