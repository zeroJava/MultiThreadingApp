using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MultiThreadingApp.LnumBasic
{
    public class PersitNumber
    {
        public static void Persist(string path, string number)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path))
                {
                    write.WriteLine(number);
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error whentrying to save");
            }
        }
    }
}
