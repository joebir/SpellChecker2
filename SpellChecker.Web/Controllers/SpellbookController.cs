using Microsoft.AspNet.Identity;
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
        public ActionResult DeletePost(int id)
        {
            GetSpellbookService().DeleteSpellbook(id);

            TempData["SaveResult"] = "Your spellbook was deleted";

            return RedirectToAction("Index");
        }
    }
}