using Microsoft.AspNet.Identity;
using SpellChecker.Contracts;
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
        private readonly Lazy<ISpell> _spellService;

        public SpellController()
        {
            _spellService = new Lazy<ISpell>(() =>
                new SpellService());
        }

        public ActionResult Index()
        {
            var model = _spellService.Value.GetAllSpells();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = _spellService.Value.GetSpellById(id);
            return View(model);
        }
    }
}