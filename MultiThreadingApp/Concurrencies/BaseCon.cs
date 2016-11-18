using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.Concurrencies
{
    public abstract class BaseCon
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public BaseCon()
        {
            //
        }

        public BaseCon(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public abstract void Action();
        
        public void Execute()
        {
            Display();
            Action();
        }
        
        public virtual void Display()
        {
            System.Console.WriteLine("Class" + this);
        }
    }
}
