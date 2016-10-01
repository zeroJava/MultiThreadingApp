using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiThreadingApp.FileIOs
{
    public class PersistData
    {
        public void Save(List<BasicServiceTable> list)
        {
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\Abu\Documents\Programming\C#\MultiThreadingApp\DbData.xml", true))
                {
                    XmlSerializer xmlfile = new XmlSerializer(typeof(List<BasicServiceTable>));
                    xmlfile.Serialize(writer, list);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error encountered when trying to persist.");
            }
        }
    }
}
