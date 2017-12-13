using Microsoft.AspNet.Identity;
using SpellChecker.Data;
using SpellChecker.Models;
using SpellChecker.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpellChecker.Web.Controllers
{
    public class EntryController : Controller
    {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int spellId)
        {
            if (!ModelState.IsValid) return RedirectToAction("Index", "SpellController"); ;

            if(!GetEntryService().CreateEntry(spellId))
            {
                ModelState.AddModelError("", "Unable to add the spell to your spellbook");
                return RedirectToAction("Index", "SpellController");
            }

            TempData["SaveResult"] = "The spell was added to your spellbook.";

            return RedirectToRoute("Index", "SpellController");
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