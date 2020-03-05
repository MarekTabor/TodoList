using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TodoList.Data;
using TodoList.Models;

namespace TodoList.Controllers
{
    public class TodoListsController : Controller
    {
        private readonly TodoListContext _context;

        public TodoListsController(TodoListContext context)
        {
            _context = context;
        }

        // GET: TodoLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.TodoList.ToListAsync());
        }

        // GET: TodoLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoLists = await _context.TodoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoLists == null)
            {
                return NotFound();
            }

            return View(todoLists);
        }

        // GET: TodoLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TodoLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,AddedDate,FinishedDate,Descripion,Priority")] TodoLists todoLists)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todoLists);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoLists);
        }

        // GET: TodoLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoLists = await _context.TodoList.FindAsync(id);
            if (todoLists == null)
            {
                return NotFound();
            }
            return View(todoLists);
        }

        // POST: TodoLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,AddedDate,FinishedDate,Descripion,Priority")] TodoLists todoLists)
        {
            if (id != todoLists.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todoLists);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoListsExists(todoLists.Id))
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
            return View(todoLists);
        }

        // GET: TodoLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todoLists = await _context.TodoList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todoLists == null)
            {
                return NotFound();
            }

            return View(todoLists);
        }

        // POST: TodoLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todoLists = await _context.TodoList.FindAsync(id);
            _context.TodoList.Remove(todoLists);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoListsExists(int id)
        {
            return _context.TodoList.Any(e => e.Id == id);
        }
    }
}
