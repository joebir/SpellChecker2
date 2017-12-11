using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Data
{
    public class Spell
    {
        [Key]
        public int SpellId { get; set; }

        [Required]
        public string SpellName { get; set; }

        [Required]
        public int SpellLevel { get; set; }

        [Required]
        public string SpellSchool { get; set; }

        [Required]
        public string CastingTime { get; set; }

        [Required]
        public string SpellRange { get; set; }

        [Required]
        public bool VComponents { get; set; }

        [Required]
        public bool SComponents { get; set; }

        [Required]
        public bool HasMComponents { get; set; }

        [Required]
        public bool HasExpensiveMComponents { get; set; }

        public string MComponents { get; set; }

        [Required]
        public string Duration { get; set; }

        [Required]
        public bool Concentration { get; set; }

        [Required]
        public bool Ritual { get; set; }

        [Required]
        public string SpellTextA { get; set; }
        public string SpellTextB { get; set; }
        public string SpellTextC { get; set; }
        public string SpellTextD { get; set; }
        public string SpellTextE { get; set; }
        public string SpellTextF { get; set; }
        public string SpellTextG { get; set; }
        public string SpellTextH { get; set; }
        public string SpellTextI { get; set; }

        [Required]
        public string SpellSource { get; set; }

        [Required]
        public bool BrdSpell { get; set; }

        [Required]
        public bool ClrSpell { get; set; }

        [Required]
        public bool DrdSpell { get; set; }

        [Required]
        public bool PalSpell { get; set; }

        [Required]
        public bool RngSpell { get; set; }

        [Required]
        public bool SorSpell { get; set; }

        [Required]
        public bool WarSpell { get; set; }

        [Required]
        public bool WizSpell { get; set; }
    }
}
