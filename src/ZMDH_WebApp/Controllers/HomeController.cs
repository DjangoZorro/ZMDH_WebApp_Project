using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZMDH_WebApp.Models;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Data;


namespace ZMDH_WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DBManager _context;


        public HomeController(ILogger<HomeController> logger,DBManager context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }




        // GET: Home/Chat
        public async Task<IActionResult> Chat()
        {
            return View(await _context.SelfHelpGroups.ToListAsync());
        }

        public IActionResult Contact()
        {
            return View();
        }
        
        public IActionResult OverOns()
        {
            return View();
        }

        public IActionResult Klachten()
        {
            return View();
        }
        
        public IActionResult FAQ()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

//         public ActionResult storeList()
// {     
//     SelfHelpGroup obj=new SelfHelpGroup();
//     obj.MySelfHelpGroup = new List<SelfHelpGroup>();// Load your list using uery  
//     return View(obj);
// }

    }
}