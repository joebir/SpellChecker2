using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Models
{
    public class EntryCreateModel
    {
        [Key]
        public int EntryId { get; set; }

        [Required]
        public string SpellId { get; set; }

        [Required]
        public string SpellbookId { get; set; }
    }
}
