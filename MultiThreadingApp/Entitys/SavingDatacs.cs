using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.Entitys
{
    public class SavingDatacs
    {
        public void Execute()
        {
            using (var context = new ServiceDBContext())
            {
                var item = new BasicServiceTable();
                item.GUIDS = Guid.NewGuid();
                item.DATE = DateTime.Now;
                context.BasicServiceTables.Add(item);
                context.SaveChanges();
            }
        }
    }
}
