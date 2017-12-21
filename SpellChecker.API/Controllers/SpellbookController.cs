using Microsoft.AspNet.Identity;
using SpellChecker.Models;
using SpellChecker.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SpellChecker.API.Controllers
{
    public class SpellbookController : ApiController
    {
        // GET /api/spellbook
        public IHttpActionResult Get()
        {
            var spellbooks = CreateSpellbookService().GetSpellbooks();

            return Ok(spellbooks);
        }

        // GET /api/spellbook/5
        public IHttpActionResult Get(int id)
        {
            var spellbook = CreateSpellbookService().GetSpells(id);

            return Ok(spellbook);
        }

        // POST /api/spellbook
        public IHttpActionResult Post(SpellbookCreateModel spellbook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateSpellbookService();

            if (!svc.CreateSpellbook(spellbook))
                return InternalServerError();

            return Ok();
        }

        // PUT /api/spellbook/id
        public IHttpActionResult Put(SpellbookEditModel spellbook)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = CreateSpellbookService();

            if (!svc.UpdateSpellbook(spellbook))
                return InternalServerError();

            return Ok();
        }

        // DELETE /api/spellbook/id
        public IHttpActionResult Delete(int id)
        {
            var svc = CreateSpellbookService();

            if (!svc.DeleteSpellbook(id))
                return InternalServerError();

            return Ok();
        }

        private SpellbookService CreateSpellbookService()
        {
            var id = Guid.Parse(User.Identity.GetUserId());
            var svc = new SpellbookService(id);
            return svc;
        }
    }
}
