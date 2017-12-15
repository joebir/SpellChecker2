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

        public SpellbookService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSpellbook(SpellbookCreateModel model)
        {
            var entity = new Spellbook()
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

        public SpellbookListItem GetSpellbookById(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Spellbooks
                    .SingleOrDefault(e => e.SpellbookId == spellbookId && e.UserId == _userId);

                return
                    new SpellbookListItem
                    {
                        SpellbookName = entity.SpellbookName,
                        UserId = entity.UserId
                    };
            }
        }

        public IEnumerable<SpellbookListItem> GetSpellbooks()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return
                    ctx.Spellbooks
                    .Where(e => e.UserId == _userId)
                    .Select(e =>
                        new SpellbookListItem
                        {
                            SpellbookId = e.SpellbookId,
                            SpellbookName = e.SpellbookName
                        })
                        .ToArray();
            }
        }

        public IEnumerable<SpellListItem> GetSpells(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                throw new NotImplementedException();
            }
        }

        public bool SetActiveSpellbook(int spellbookId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var spellbook = GetSpellbookById(spellbookId);

                if (spellbook.UserId != _userId) return false;

                string userId = _userId.ToString();

                var entity =
                    ctx.Users
                    .SingleOrDefault(e => e.Id == userId);

                entity.CurrentSpellbook = spellbookId;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
