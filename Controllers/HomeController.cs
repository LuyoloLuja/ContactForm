using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactForm.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace ContactForm.Controllers;

public class HomeController : Controller
{
    private readonly ContactFormDbContext _context;

    public HomeController(ContactFormDbContext context) {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new DetailsViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Index(DetailsViewModel model) 
    {
        if(!ModelState.IsValid && model.IsChecked == false) {
            return View(model);
        }
        _context.Details.Add(model); // add user inputs to the db
        await _context.SaveChangesAsync(); // save to the db
        return PartialView("_SuccessModal", model);
    }

    [HttpGet]
    public async Task<IActionResult> Users() {
        var data = await _context.Details.ToListAsync();
        if(data == null) 
        {
            return NotFound();
        }
        return View(data);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteAll() 
    {
        var model = _context.Details.ToList();
        if(model.Any()) 
        {
            _context.Details.RemoveRange(model);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id) {
        DetailsViewModel model = _context.Details.Find(id);
        if(model == null)
        {
            return NotFound();
        }
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        DetailsViewModel model = await _context.Details.FindAsync(id);
        if(model != null)
        {
            _context.Details.Remove(model);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
