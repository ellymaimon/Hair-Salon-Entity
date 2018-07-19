using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Linq;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class StylistsController : Controller
    {
        private HairSalonContext db = new HairSalonContext();

        public IActionResult Index()
        {
            List<Stylist> model = db.Stylists.ToList();
            return View(model);
        }

        public IActionResult Details(int id)
        {
            Stylist thisStylist = db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
            return View(thisStylist);
        }
    }
}