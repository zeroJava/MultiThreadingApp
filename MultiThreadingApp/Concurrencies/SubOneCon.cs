using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.Concurrencies
{
    public class SubOneCon : BaseCon
    {
        public string Type { get; set; }

        public SubOneCon() : base()
        {
            //
        }

        public SubOneCon(int id, string name, string type) : base(id, name)
        {
            Type = type;
        }

        public override void Action()
        {
            System.Console.WriteLine("Hello");
        }

        public override void Display()
        {
            base.Display();
            System.Console.WriteLine("Class:" + this);
        }

        public override string ToString()
        {
            return Id + " " + Name + " " + Type;
        }
    }
}
