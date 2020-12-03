using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AigisProjekt.Models;
using AigisProjekt.Data;

namespace AigisProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly Database _context;

        public HomeController(Database context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }


        public IActionResult Index()
        {
            
                // Create and save a new Blog.InvalidOperationException: "No database provider has been configured for this DbContext. 
                Console.Write("Enter a name for a Markmanagement System ");
                var name = "Peter";

                var stud = new Student { Name = name };
                _context.Student.Add(stud);
            _context.SaveChanges();

                // Display all Blogs from the database
                var query = from b in _context.Student
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
            

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
