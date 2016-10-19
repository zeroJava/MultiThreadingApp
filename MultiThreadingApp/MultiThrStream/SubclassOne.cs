using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.MultiThrStream
{
    [Serializable]
    public class SubclassOne : Baseclass
    {
        public string OrganismType { get; set; }

        public SubclassOne() : base()
        {
            //
        }

        public SubclassOne(string name, int age, string organismType) : base(name, age, DateTime.Now)
        {
            OrganismType = organismType;
        }
    }
}
