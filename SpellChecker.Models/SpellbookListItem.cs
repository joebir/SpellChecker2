﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Models
{
    public class SpellbookListItem
    {
        [Key]
        public int SpellbookId { get; set; }

        [Required]
        public string SpellbookName { get; set; }
        [Required]
        public Guid UserId { get; set; }
    }
}
