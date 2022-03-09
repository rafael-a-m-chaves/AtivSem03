using Agenda.Application.IServices;
using Agenda.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.WebApplication.Controllers
{
    public class ClienteController : Controller
    {
        // criando o a injeção de dependencia do service na controller
        private readonly IClienteService service;
        public ClienteController(IClienteService _clienteService) : base()
        {
            service = _clienteService;
        }

        // GET: ClienteController
        public ActionResult Index()
        {
            IEnumerable<Cliente> cliente;
            cliente = service.Get().ToList();

            return View(cliente);
        }

        // GET: ClienteController/Details/5
        public ActionResult Details(int id)
        {
            Cliente cliente = service.FindById(id);
            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return Index();
            }
            
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Cliente cliente = new Cliente();
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Edit/5
        public ActionResult Edit(int id)
        {
            Cliente cliente = service.FindById(id);
            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return Index();
            }
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            Cliente cliente = service.FindById(id);
            if (cliente != null)
            {
                return View(cliente);
            }
            else
            {
                return Index();
            }
        }

        // POST: ClienteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Cliente cliente = service.FindById(id);
                if (cliente != null)
                {
                    service.Delete(cliente);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
