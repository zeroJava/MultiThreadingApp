using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.Entitys
{
    public class RetrievingData
    {
        public int Size()
        {
            int size = 0;

            using (var _context = new ServiceDBContext())
            {
                size = _context.BasicServiceTables.Count();
            }

            return size;
        }
    }
}
