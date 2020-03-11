using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public class LearningCycle
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }

        public virtual List<LearningObjective> LearningObjectives { get; set; }
    }
}
