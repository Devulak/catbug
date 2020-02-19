using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public class EntryCategory
    {
        public int Id { get; set; }

        [Required]
        public int EntryId { get; set; }
        public virtual Entry Entry { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
