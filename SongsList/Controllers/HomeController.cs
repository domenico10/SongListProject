using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SongsList.Models;

namespace SongsList.Controllers
{
    public class HomeController : Controller
    {
        private SongContext context { get; set; } //CREATE THE TYPE OF THE CONTEXT

        public HomeController(SongContext ctx) //INJECT THE DBCONTEXT INTO THE CONTROLLER PASSING IT INTO THE CONTRUCTOR
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            var songs = context.Songs.Include(a => a.Genre).OrderBy(a => a.Name).ToList();
            return View(songs);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
