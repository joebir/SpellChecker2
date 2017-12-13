using SpellChecker.Data;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Contracts
{
    public interface ISpellbook
    {
        IEnumerable<SpellbookListItem> GetSpellbooks(Guid userId);
        IEnumerable<SpellListItem> GetSpells(int spellbookId);
        bool CreateSpellbook(SpellbookCreateModel model);
        bool DeleteSpellbook(int spellbookId);
    }
}
