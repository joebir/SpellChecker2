using Microsoft.AspNet.Identity;
using SpellChecker.Data;
using SpellChecker.Models;
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

        [Authorize]
        private EntryService GetEntryService()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var user =
                    ctx.Users
                    .Single(e => e.Id == User.Identity.GetUserId());

                return new EntryService(user.CurrentSpellbook);
            }
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id)
        {
            if (!GetEntryService().CreateEntry(id))
            {
                TempData["SaveResult"] = "Unable to add the spell to your spellbook.";
                return RedirectToAction("Index", "SpellController");
            }

            TempData["SaveResult"] = "The spell was added to your spellbook.";

            return RedirectToAction("Index");
        }
    }
}