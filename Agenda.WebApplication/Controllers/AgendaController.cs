using Agenda.Application.IServices;
using Agenda.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.WebApplication.Controllers
{
    public class AgendaController : Controller
    {
        // criando o a injeção de dependencia do service na controller
        private readonly IAgendaService service;
        private readonly IClienteService clienteService;
        private readonly IProcedimentoService procedimentoService;
        public AgendaController(IAgendaService agendaService, 
            IClienteService _clienteService, IProcedimentoService _procedimentoService) : base() 
        {
            service = agendaService;
            clienteService = _clienteService;
            procedimentoService = _procedimentoService; 
        }

        // GET: AgendaController
        public ActionResult Index()
        {
            IEnumerable<Agendas> agendas;
            agendas = service.Get().ToList();
            return View(agendas);
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            Agendas agendas = service.FindById(id);
            if(agendas != null)
            {
                return View(agendas);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
            
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            var clientes = clienteService.Get().ToList();
            var procedimentos = procedimentoService.Get().ToList();

            Models.Agendas agendas = new Models.Agendas(); //Usado outro objeto para evitar conflitos no bd
            agendas.ProcedimentoList = procedimentos;
            agendas.ClienteList = clientes;
            return View(agendas);
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Agendas agendas = new Agendas();
                agendas.Id = 0;
                agendas.IdCliente = Convert.ToInt32(collection["IdCliente"]);
                agendas.IdProcedimento = Convert.ToInt32(collection["IdProcedimento"]);
                agendas.DataAgendamento = Convert.ToDateTime(collection["DataAgendamento"]);
                agendas.Realizado = Convert.ToBoolean(collection["Realizado"]);
                service.Save(agendas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var clientes = clienteService.Get().ToList();
                var procedimentos = procedimentoService.Get().ToList();

                Models.Agendas agendas = new Models.Agendas(); //Usado outro objeto para evitar conflitos no bd
                agendas.ProcedimentoList = procedimentos;
                agendas.ClienteList = clientes;
                return View(agendas);
            }
        }

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            Agendas agendas = service.FindById(id);
            if (agendas != null)
            {
                return View(agendas);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AgendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                Agendas agendas = new Agendas();
                agendas.Id = id;
                agendas.DataAgendamento = Convert.ToDateTime(collection["DataAgendamento"]);
                agendas.Realizado = Convert.ToBoolean(collection["Realizado"]);
                service.Save(agendas);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            Agendas agendas = service.FindById(id);
            if (agendas != null)
            {
                return View(agendas);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Agendas agendas = service.FindById(id);
                if (agendas != null)
                {
                    service.Delete(agendas);
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
