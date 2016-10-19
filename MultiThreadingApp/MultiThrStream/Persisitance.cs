using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiThreadingApp.MultiThrStream
{
    public static class Persisitance
    {
        private static ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

        public static void PersistObject(Baseclass data)
        {
            _rwlock.EnterWriteLock();
            try
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\Users\Abu\Documents\Programming\C#\MultiThreadingApp\attri.xml", true))
                {
                    XmlSerializer xmlfile = new XmlSerializer(typeof(Baseclass));
                    xmlfile.Serialize(writer, data);
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Error encountered when trying to persist.");
            }
            finally
            {
                _rwlock.ExitWriteLock();
            }
        }
    }
}
