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
        [Description("App developmentD")]
        AppDevelopment,

        [Display(Name = "Computer security")]
        [Description("Computer securityD")]
        ITSecurity,

        [Display(Name = "Machine learning")]
        [Description("Machine learningD")]
        MachineLearning,

        [Display(Name = "Web development")]
        [Description("Web developmentD")]
        WebDevelopment
    }

    public class Entry
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [DataType(DataType.MultilineText)]
        public string Context { get; set; }

        public EntryCategory Category { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
