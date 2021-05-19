using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SongsList.Models;

namespace SongsList.Controllers
{
    public class SongController : Controller
    {
        private SongContext context { get; set; }
        public SongController(SongContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Genres = context.Genres.OrderBy(a => a.Name).ToList();
            return View("Edit", new Song());
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Genres = context.Genres.OrderBy(a => a.Name).ToList();
            var song = context.Songs.Find(Id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Edit(Song song)
        {
            if (ModelState.IsValid)
            {
                if (song.SongId == 0)
                {
                    context.Songs.Add(song);
                }
                else
                {
                    context.Songs.Update(song);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = song.SongId == 0 ? "Add" : "Edit";
                ViewBag.Genres = context.Genres.OrderBy(a => a.Name).ToList();
                return View(song);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var song = context.Songs.Find(Id);
            return View(song);
        }

        [HttpPost]
        public IActionResult Delete(Song song)
        {
            context.Songs.Remove(song);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
