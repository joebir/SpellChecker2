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
    public class EntryController : Controller
    {
        private readonly Lazy<IEntry> _entryService;

        public EntryController()
        {
            _entryService = new Lazy<IEntry>(() =>
                new EntryService());
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string spellId, string spellbookId)
        {
            _entryService.Value.CreateEntry(Int32.Parse(spellId), Int32.Parse(spellbookId));

            return RedirectToAction("Index");
        }
    }
}