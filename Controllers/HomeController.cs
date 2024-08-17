using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactForm.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactForm.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new DetailsViewModel());
    }

    [HttpPost]
    public IActionResult Index(DetailsViewModel model) 
    {
        if(!ModelState.IsValid && model.IsChecked == false) {
            return View(model);
        }
        return PartialView("_SuccessModal", model);
    }
}
