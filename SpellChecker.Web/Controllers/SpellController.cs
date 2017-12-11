using SpellChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpellChecker.Web.Controllers
{
    public class SpellController : Controller
    {
        private SpellService GetSpellService()
        {
            var svc = new SpellService();
            return svc;
        }

        // GET: Spell
        public ActionResult Index()
        {
            var model = GetSpellService().GetAllSpells();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = GetSpellService().GetSpellById(id);
            return View(model);
        }
    }
}