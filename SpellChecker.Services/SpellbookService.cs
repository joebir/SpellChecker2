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
    public class SpellbookService : ISpellbook
    {
        public bool CreateSpellbook(SpellbookCreateModel model)
        {
            var entity = new Spellbook()
            {
                SpellbookName = model.SpellbookName
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spellbooks.Add(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSpellbook(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Spellbooks
                    .SingleOrDefault(e => e.SpellbookId == spellbookId);

                if (entity == null) return false;

                ctx.Spellbooks.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpellbookListItem> GetSpellbooks(Guid userId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx.Spellbooks
                    .Where(e => e.UserId == userId)
                    .Select(e =>
                        new SpellbookListItem
                        {
                            SpellbookName = e.SpellbookName
                        })
                        .ToArray();
            }
        }

        public IEnumerable<SpellListItem> GetSpells(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = new SpellService();

                return
                    ctx.Entries
                    .Where(e => e.SpellbookId == spellbookId)
                    .Select(e =>
                        new SpellListItem
                        {
                            SpellName = svc.GetSpellById(e.SpellId).SpellName,
                            SpellLevel = svc.GetSpellById(e.SpellId).SpellLevel,
                            SpellSchool = svc.GetSpellById(e.SpellId).SpellSchool,
                            CastingTime = svc.GetSpellById(e.SpellId).CastingTime,
                            SpellRange = svc.GetSpellById(e.SpellId).SpellRange,
                            VComponents = svc.GetSpellById(e.SpellId).VComponents,
                            SComponents = svc.GetSpellById(e.SpellId).SComponents,
                            HasMComponents = svc.GetSpellById(e.SpellId).HasMComponents,
                            Duration = svc.GetSpellById(e.SpellId).Duration,
                        }).ToArray();
            }
        }
    }
}
