using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CadastroAluno.Data;
using CadastroAluno.Models;
using CadastroAluno.Contracts;

namespace CadastroAluno.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepository _context;

        public AlunosController(IAlunosRepository context)
        {
            _context = context;
        }

        // GET: Alunos
        public IActionResult Index()
        {
            return View(_context.GetAlunos());
        }

        // GET: Alunos/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = _context.GetAlunoById(id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // GET: Alunos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Alunos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Nome,Turma,Media")] Alunos alunos)
        {
            if (ModelState.IsValid)
            {
                _context.AddAluno(alunos);

                return RedirectToAction(nameof(Index));
            }
            return View(alunos);
        }

        // GET: Alunos/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos = _context.GetAlunoById(id);
            if (alunos == null)
            {
                return NotFound();
            }
            return View(alunos);
        }

        // POST: Alunos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Nome,Turma,Media")] Alunos alunos)
        {
            if (id != alunos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.UpdateAluno(id, alunos);
                return RedirectToAction(nameof(Index));
            }

            return View(alunos);
        }

        // GET: Alunos/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alunos =  _context.GetAlunoById(id);
            if (alunos == null)
            {
                return NotFound();
            }

            return View(alunos);
        }

        // POST: Alunos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            var alunos =  _context.GetAlunoById(id);
            _context.DeleteAluno(alunos.Id);          
            return RedirectToAction(nameof(Index));
        }
       
    }
}
