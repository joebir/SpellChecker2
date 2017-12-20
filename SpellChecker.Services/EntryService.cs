using SpellChecker.Contracts;
using SpellChecker.Data;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Services
{
    public class EntryService : IEntry
    {
        public bool CreateEntry(int spellId, int spellbookId)
        {
            var entity =
                    new Entry
                    {
                        SpellId = spellId,
                        SpellbookId = spellbookId
                    };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entries.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteEntry(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Entries
                    .SingleOrDefault(e => e.EntryId == id);

                if (entity == null) return false;

                ctx.Entries.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public int GetEntrySpellbook(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Entries
                    .SingleOrDefault(e => e.EntryId == id);

                return entity.SpellbookId;
            }
        }
    }
}
