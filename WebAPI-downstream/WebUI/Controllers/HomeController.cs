using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebUI.HystrixServices;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller

    {
        private BookService service; 
        public HomeController(BookService service) //Injecting Hystrix Service to Execute   
        {
            this.service = service;
           
        }
        public IActionResult Index()
        {
            var list = service.Execute();
            ViewData["list"] = list;
            return View();

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
