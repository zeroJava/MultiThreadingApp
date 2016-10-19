using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiThreadingApp.MultiThrStream
{
    [Serializable]
    [XmlInclude(typeof(SubclassOne))]
    [XmlInclude(typeof(SubclassTwo))]
    public abstract class Baseclass
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateNTime { get; set; }

        public Baseclass()
        {
            //
        }

        public Baseclass(string name, int age, DateTime datetime)
        {
            Name = name;
            Age = age;
            DateNTime = datetime;
        }
    }
}
