using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.MultiThrStream
{
    [Serializable]
    public class SubclassTwo : Baseclass
    {
        public string MechanicType { get; set; }

        public SubclassTwo() : base()
        {
            //
        }

        public SubclassTwo(string name, int age, DateTime datetime, string mechanicType) : base(name, age, datetime)
        {
            MechanicType = mechanicType;
        }
    }
}
