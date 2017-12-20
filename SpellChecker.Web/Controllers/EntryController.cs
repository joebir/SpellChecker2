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
        public ActionResult Create(EntryCreateModel entry)
        {
            _entryService.Value.CreateEntry(Int32.Parse(entry.SpellId), Int32.Parse(entry.SpellbookId));

            return RedirectToAction("Index");
        }
    }
}