using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreRepo.Models
{
    public class CaseVM
    {
        public int Year { get; set; }
        public virtual ICollection<Agencies> Agencies { get; set; }
       // public virtual ICollection<Attorneys> Attorneys { get; set; }
        //public string Attorneys { get; set; }
    }

    public class Agencies
    {
        public string Agency { get; set; }
        public int Total { get; set; }
        public virtual ICollection<Attorneys> Attorneys { get; set; }
    }

    public class Attorneys
    {
        public string Attorney { get; set; }
        public int Total { get; set; }
       
    }
}


