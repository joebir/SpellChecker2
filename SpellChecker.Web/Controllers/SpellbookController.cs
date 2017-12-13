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
    public class SpellbookController : Controller
    {
        [Authorize]
        private SpellbookService GetSpellbookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

            return new SpellbookService(userId);
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

        // GET: Spellbook
        public ActionResult Index(int id)
        {
            var model = GetSpellbookService().GetSpells(id);
            return View(model);
        }

        public ActionResult Create()
        {
            var model = new SpellbookCreateModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellbookCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if (!GetSpellbookService().CreateSpellbook(model))
            {
                ModelState.AddModelError("", "Unable to create spellbook");
                return View(model);
            }

            TempData["SaveResult"] = "Your spellbook was created";

            return RedirectToAction("Index");
        }

        [ActionName("Delete")]
        public ActionResult DeleteSpellbookGet(int id)
        {
            var model = GetSpellbookService().GetSpellbookById(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteSpellbookPost(int id)
        {
            GetSpellbookService().DeleteSpellbook(id);

            TempData["SaveResult"] = "Your spellbook was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            GetEntryService().DeleteEntry(id);

            TempData["SaveResult"] = "The spell was removed from your spellbook.";

            return RedirectToAction("Index", "SpellbookController");
        }
    }
}