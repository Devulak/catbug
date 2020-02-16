using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public enum EntryCategory
    {
        [Display(Name = "App development")]
        [Description("App development")]
        AppDevelopment,

        [Description("Computer security")]
        ITSecurity,

        [Display(Name = "Machine learning")]
        [Description("Machine learning")]
        MachineLearning,

        [Display(Name = "Web development")]
        [Description("Web development")]
        WebDevelopment
    }

    public class Entry
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Context { get; set; }

        public EntryCategory Category { get; set; }
    }
}
