using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public class Entry
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Context { get; set; }

        public virtual List<EntryCategory> EntryCategories { get; set; }

        [BindNever]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
