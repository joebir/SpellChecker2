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
        IEnumerable<SpellListItem> GetSpells(int spellbookId);
        bool AddEntry(int spellbookId, int spellId);
        bool DeleteEntry(int spellbookId, int entryId);
        Spellbook GetSpellbookById(int spellbookId);
        int GetSpellCount(int spellbookId);
        bool DeleteSpellbook(int spellbookId);
    }
}
