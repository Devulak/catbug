using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace catbug.Models
{
    public class LearningObjective
    {
        public int Id { get; set; }

        public string Goal { get; set; }
        public string Techniques { get; set; }
        public string Criteria { get; set; }
        public string Completed { get; set; }
        public string Evaulation { get; set; }

        public int LearningCycleId { get; set; }
        public virtual LearningCycle LearningCycle { get; set; }
    }
}
