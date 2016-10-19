using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.LnumBasic
{
    public class MassiveNumberCreator
    {
        public BigInteger _massiveNumber;

        public MassiveNumberCreator(string number)
        {
            BigInteger.TryParse(number, out _massiveNumber);
        }

        public void Execute()
        {
            _massiveNumber = BigInteger.Pow(_massiveNumber, 2);
            //_massiveNumber = BigInteger.Add(_massiveNumber, new BigInteger(2));
        }

        public string GetMassiveNumber()
        {
            return _massiveNumber.ToString();
        }
    }
}
