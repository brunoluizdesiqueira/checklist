using System.Linq;
using CheckList.Models;
using CheckList.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CheckList.Controllers
{
    public class TarefaController : Controller
    {
        private readonly TarefaRepository tarefaRepository;

        public TarefaController(IConfiguration configuration){
            tarefaRepository = new TarefaRepository(configuration);
        }

        // GET: Tarefas
        public ActionResult Index()
        {
            return View(tarefaRepository.FindAll().ToList());
        }

        // GET: Tarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            Tarefa tarefa = tarefaRepository.FindByID(id.Value);
            if (tarefa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tarefa);
        }

        // GET: Tarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id,Titulo,Descricao,Status")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefaRepository.Add(tarefa);
                return RedirectToAction("Index");
            }

            return View(tarefa);
        }

        // GET: Tarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tarefa tarefa = tarefaRepository.FindByID(id.Value);
            if (tarefa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tarefa);
        }

        // POST: Tarefas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Titulo,Descricao,Status")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                tarefaRepository.Update(tarefa);
                return RedirectToAction("Index");
            }
            return View(tarefa);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            Tarefa tarefa = tarefaRepository.FindByID(id.Value);
            if (tarefa == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
            return View(tarefa);
        }

        // POST: Tarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tarefaRepository.Remove(id);
            return RedirectToAction("Index");
        }


    }
}