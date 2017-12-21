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
    public class EntryController : ApiController
    {
        // POST /api/entry
        public IHttpActionResult Post(EntryCreateModel entry)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var svc = new EntryService();

            if (!svc.CreateEntry(Int32.Parse(entry.SpellId), Int32.Parse(entry.SpellbookId)))
                return InternalServerError();

            return Ok();
        }
    }
}
