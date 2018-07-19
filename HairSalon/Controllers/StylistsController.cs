using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        public IActionResult Index()
        {
            List<Stylist> model = db.Stylists.ToList();
            return View(db.Stylists.Include(stylists => stylists.Client).ToList());
        }

        public IActionResult Details(int id)
        {
            Stylist thisStylist = db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }

        public IActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Stylist stylist)
        {
            db.Stylists.Add(stylist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var thisStylist= db.Stylists.FirstOrDefault(items => items.StylistId == id);
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "Name");
            return View(thisStylist);
        }

        [HttpPost]
        public IActionResult Edit(Stylist stylist)
        {
            db.Entry(stylist).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisStylist = db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisStylist = db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            db.Stylists.Remove(thisStylist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}