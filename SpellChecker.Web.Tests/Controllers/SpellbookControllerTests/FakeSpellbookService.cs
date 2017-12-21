using SpellChecker.Contracts;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Web.Tests.Controllers.SpellbookControllerTests
{
    public class FakeSpellbookService : ISpellbook
    {
        public int CreateSpellbookCallCount { get; private set; }
        public bool CreateSpellbookReturnValue { private get; set; } = true;

        public bool CreateSpellbook(SpellChecker.Models.SpellbookCreateModel model)
        {
            CreateSpellbookCallCount++;

            return CreateSpellbookReturnValue;
        }

        public bool DeleteSpellbook(int spellbookId)
        {
            throw new NotImplementedException();
        }

        public SpellChecker.Models.SpellbookListItem GetSpellbookById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpellChecker.Models.SpellbookListItem> GetSpellbooks()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SpellChecker.Models.EntryListItem> GetSpells(int spellbookId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateSpellbook(SpellbookEditModel model)
        {
            throw new NotImplementedException();
        }
    }
}
