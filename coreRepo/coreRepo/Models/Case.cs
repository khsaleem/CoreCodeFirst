using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreRepo.Models
{

    public class Case
    {
        public int CaseNumber { get; set; }
        public int Year { get; set; }
        public string Agency { get; set; }
        public string Attorney { get; set; }
    }
}
