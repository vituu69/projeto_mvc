using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProjct.Data;
using WebProjct.Models;


namespace WebProjct.Controllers
{
    public class DepartmentsController : Controller
    {
        private readonly WebProjctContext _context;

        public DepartmentsController(WebProjctContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Department> departments = _context.Department.ToList();
            return View(departments);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Department.Add(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        public IActionResult Editar(int id)
        {
            var departmento = _context.Department.Find(id);
            if (departmento == null)
            {
                return NotFound();
            }
            return View(departmento);
        }

        [HttpPost]
        public IActionResult Editar(Department department)
        {
            if (ModelState.IsValid)
            {
                _context.Department.Update(department);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }
        public IActionResult ApagarConfirmacao(int id)
        {
            var departamento = _context.Department.Find(id);
            if (departamento == null)
                return NotFound();
            return View(departamento);
        }
        public IActionResult Apagar(int id)
        {
            var departamento = _context.Department.Find(id);
            if (departamento == null)
                return NotFound();

            _context.Department.Remove(departamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}