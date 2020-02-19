using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<EntryCategory> EntryCategories { get; set; }
    }
}
