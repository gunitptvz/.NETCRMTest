using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitmentDEV.Data
{
    /// <summary>
    /// Contains candidate entity data properties
    /// </summary>
    public class CandidateDataModel
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Owner { get; set; }
    }
}
