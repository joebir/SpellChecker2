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
        IEnumerable<SpellbookListItem> GetSpellbooks();
        IEnumerable<EntryListItem> GetSpells(int spellbookId);
        bool CreateSpellbook(SpellbookCreateModel model);
        SpellbookListItem GetSpellbookById(int id);
        bool DeleteSpellbook(int spellbookId);
        bool SetActiveSpellbook(int spellbookId);
    }
}
