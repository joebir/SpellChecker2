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
        bool CreateEntry(int spellId);
        bool DeleteEntry(int id);
    }
}
