using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Models
{
    public class EntryListItem
    {
        [Key]
        public int EntryId { get; set; }

        [Required]
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
        public string Duration { get; set; }
    }
}
