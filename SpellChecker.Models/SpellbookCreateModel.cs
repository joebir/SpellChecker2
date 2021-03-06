﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpellChecker.Models
{
    public class SpellbookCreateModel
    {
        [Key]
        public int SpellbookId { get; set; }

        [Required]
        public string SpellbookName { get; set; }
    }
}
