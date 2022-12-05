using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CTTProject.Migrations;
using CTTProject.Models;
using CTTProject.Service;

namespace CTTProject.Controllers
{
    public class ProjectsController : Controller
    {
        //private readonly ProjectDb _context;
        private readonly ICRUD _service;
        public ProjectsController(ICRUD service)
        {
            _service = service;
        }

        // GET: Projects

        public async Task<IActionResult> Index(int? id)
        {
            return View("Index", await _service.ReadByIdAsync(1));

        }    



        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _service.ProjectExist == null)
            {
                return NotFound();
            }

            var project = await _service.ReadAsync(id);
                
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProjectName,ProjectFundProgress,Description")] Project project)
        {
            if (ModelState.IsValid)
            {

                await _service.CreateProjectAsync(project);
                return RedirectToAction(nameof(Index));
               

            }
            return View(project);
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _service.ProjectExist == null)
            {
                return NotFound();
            }

            var project = await _service.ReadAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProjectName,ProjectFundProgress,Description")] Project project)
        {
            if (id != project.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _service.UpdateAsync(project);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_service.ProjectExists(project.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(project);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _service.ProjectExist == null)
            {
                return NotFound();
            }

            var project = await _service.ReadAsync(id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_service.ProjectExist == null)
            {
                return Problem("Entity set 'ProjectDb.Projects'  is null.");
            }
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
            /*
            var project = await _service.Projects.FindAsync(id);
            if (project != null)
            {
                _service.Projects.Remove(project);
            }
            
            await _service.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            }
            */
        }
        /*
        private bool ProjectExists(int id)
        {
          return _context.Projects.Any(e => e.Id == id);
        }
        */
    }
}
