using SpellChecker.Data;
using SpellChecker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Contracts
{
    public interface IEntry
    {
        bool CreateEntry(int spellId, int spellbookId);
        bool DeleteEntry(int id);
        int GetEntrySpellbook(int id);
    }
}
