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
        private readonly Guid _userId;
        private readonly int _currentSpellbook;

        public SpellbookService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpellbook(SpellbookCreateModel model)
        {
            var entity =
                new Spellbook()
                {
                    SpellbookName = model.SpellbookName,
                    UserId = _userId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Spellbooks.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SpellListItem> GetSpells(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var svc = new SpellService();

                var query =
                    ctx.Entries
                    .Where(e => e.SpellbookId == spellbookId && GetSpellbookById(spellbookId).UserId == _userId)
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
                        }
                     );

                return query.ToArray();
            }
        }

        public Spellbook GetSpellbookById(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Spellbooks
                    .Single(e => e.SpellbookId == spellbookId && e.UserId == _userId);

                return new Spellbook
                {
                    SpellbookId = entity.SpellbookId,
                    SpellbookName = entity.SpellbookName,
                    UserId = entity.UserId
                };
            }
        }

        public int GetSpellCount(int spellbookId)
        {
            return GetSpells(spellbookId).Count();
        }

        public bool DeleteSpellbook(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Spellbooks
                    .Single(e => e.SpellbookId == spellbookId && e.UserId == _userId);

                int returnNum = GetSpellCount(spellbookId) + 1;

                ctx.Spellbooks.Remove(entity);
                return ctx.SaveChanges() == returnNum;
            }
        }
    }
}
