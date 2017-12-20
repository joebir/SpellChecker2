using Microsoft.AspNet.Identity;
using SpellChecker.Contracts;
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
        private readonly Lazy<ISpellbook> _spellbookService;
        private readonly Lazy<IEntry> _entryService;

        public SpellbookController()
        {
            _spellbookService = new Lazy<ISpellbook>(() =>
                new SpellbookService(Guid.Parse(User.Identity.GetUserId())));

            _entryService = new Lazy<IEntry>(() =>
                new EntryService());
        }

        public ActionResult Index()
        {
            var model = _spellbookService.Value.GetSpellbooks();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _spellbookService.Value.GetSpells(id);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SpellbookCreateModel model)
        {
            if (!ModelState.IsValid) return View(model);

            if(_spellbookService.Value.CreateSpellbook(model))
            {
                TempData["SaveResult"] = "Your spellbook was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Spellbook couldn't be created");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var model = _spellbookService.Value.GetSpellbookById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            _spellbookService.Value.DeleteSpellbook(id);

            TempData["SaveResult"] = "Your spellbook was deleted";

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEntry(int id)
        {
            int spellbookId = _entryService.Value.GetEntrySpellbook(id);

            _entryService.Value.DeleteEntry(id);

            TempData["SaveResult"] = "The entry was deleted";

            return RedirectToAction("Details", spellbookId);
        }
    }
}