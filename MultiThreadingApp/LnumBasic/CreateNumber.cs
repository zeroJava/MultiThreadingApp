using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.LnumBasic
{
    public class CreateNumber
    {
        public static bool TryGetPeristedNumber(string path, out string number)
        {
            number = null;

            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    number = reader.ReadLine();
                }
            }

            if (number != null && !(number.Length == 0))
                return true;

            return false;
        }
    }
}
