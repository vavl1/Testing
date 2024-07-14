using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PAsswordRepos.Models;
using PAsswordRepos.Services;

using PAsswordRepos.Services.DbModels;
using ProjectPAsswordReposTest.Services;
using System.Diagnostics;

namespace PAsswordRepos.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(PasswordSearchParams search,string errorText)
        {
            var date = new PasswordDb().GetPasswords(search);
            ViewBag.TypePasswords = new TypePasswordDb().GetTypePasswords().Select(i => new SelectListItem { Value = i.Id.ToString(), Text = i.Name }) ;
            ViewBag.Error = errorText;
            return View(date);
        }
        public IActionResult AddPassword(PasswordModel value)
        {
            string errorText = null;
            if (ModelState.IsValid)
            {
               
                var entity = new PasswordDb().GetPasswords(new PasswordSearchParams { Name = value.Name }).FirstOrDefault();
                if(entity== null)
                {
                    new PasswordDb().AddPassword(new Password
                    {
                        Name = value.Name,
                        Date = DateTime.Now,
                        Password1 = value.Password1,
                        TypePassword = value.TypePassword
                    });
                }
                else
                {
                     errorText = "данная почта или сайт уже есть";
                }
               
               
            }
            return RedirectToAction("Index",new {errorText =errorText});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}