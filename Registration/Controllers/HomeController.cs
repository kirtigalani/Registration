using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Win32;
using Registration.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index(registration register,int i=0)
        {
            DataSet dataset = register.Select();
            ViewBag.data = dataset.Tables[0];
            return View();
        }

        [HttpGet]
        public IActionResult Delete(registration register, int id = 0)
        {
            register.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult update(registration register, int id = 0)
        {
            DataSet dataset = register.update(id);
            ViewBag.Data = dataset.Tables[0];
            return View();
        }
        [HttpPost]
        public IActionResult Index(registration register)
        {
            string FName = register.FName;
            string LName = register.LName;
            string Gender = register.Gender;
            string city = register.city;
            string State = register.State;
            string mail = register.mail;
            string DOB = register.DOB;
            string Address = register.Address;

            register.Insert(FName, LName, Gender, city, State, mail, DOB, Address);

            return RedirectToAction("Index");
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
