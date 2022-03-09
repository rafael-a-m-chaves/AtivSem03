using Agenda.Application.IServices;
using Agenda.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Agenda.WebApplication.Controllers
{
    public class ProcedimentoController : Controller
    {
        // criando o a injeção de dependencia do service na controller
        private readonly IProcedimentoService service;
        public ProcedimentoController(IProcedimentoService procedimentoService) : base()
        {
            service = procedimentoService;
        }


        // GET: ProcedimentoController1
        public ActionResult Index()
        {
            IEnumerable<Procedimento> procedimento;
            procedimento = service.Get().ToList();
            return View(procedimento);
        }

        // GET: ProcedimentoController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProcedimentoController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProcedimentoController1/Create
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

        // GET: ProcedimentoController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProcedimentoController1/Edit/5
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

        // GET: ProcedimentoController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProcedimentoController1/Delete/5
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
