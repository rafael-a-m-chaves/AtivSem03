using Agenda.Application.IServices;
using Agenda.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.WebApplication.Controllers
{
    public class AgendaController : Controller
    {
        // criando o a injeção de dependencia do service na controller
        private readonly IAgendaService service;
        public AgendaController(IAgendaService agendaService) : base() 
        {
            service = agendaService;
        }

        // GET: AgendaController
        public ActionResult Index()
        {
            IEnumerable<Agendas> agendas;
            agendas = service.Get().ToList();
            return View();
        }

        // GET: AgendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AgendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AgendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AgendaController/Edit/5
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

        // GET: AgendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AgendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
