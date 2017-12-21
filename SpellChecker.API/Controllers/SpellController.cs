using Microsoft.AspNet.Identity;
using SpellChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpellChecker.API.Controllers
{
    public class SpellController : ApiController
    {
        // GET /api/spell
        public IHttpActionResult Get(string searchString)
        {
            var spells = CreateSpellService().GetAllSpells(searchString);

            return Ok(spells);
        }

        // GET api/spell/5
        public IHttpActionResult Get(int id)
        {
            var spell = CreateSpellService().GetSpellById(id);

            return Ok(spell);
        }
        
        private SpellService CreateSpellService()
        {
            var svc = new SpellService();
            return svc;
        }
    }
}
