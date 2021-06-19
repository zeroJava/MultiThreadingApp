using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MultiThreadingApp.AsynchronousAwaits
{
	public class AsyncSimpleEg
	{
		public void Run()
		{
			Console.WriteLine("Executing 1");
			Console.WriteLine("Executing 2");

			TaskAwaiter<int> awaiter = BigNumberCountAsync(5000000).GetAwaiter();
			//Console.WriteLine(awaiter.GetResult());

			Console.WriteLine("Finshed");
		}

		private async Task<int> BigNumberCountAsync(int limit)
		{
			Console.WriteLine("Limit: " + limit);

			BigInteger bigInteger = await GetBigNumber(limit);
			Console.WriteLine("Number generated");

			int count = bigInteger.ToString().Length;
			Console.WriteLine("Count: " + count);

			return count;
		}

		private Task<BigInteger> GetBigNumber(int limit)
		{
			return Task.Factory.StartNew(() =>
			{
				BigInteger bigInteger = new BigInteger(2);
				for (int number = 0; number < limit; number++)
				{
					bigInteger = BigInteger.Multiply(bigInteger, new BigInteger(2));
				}
				return bigInteger;
			});
		}
	}
}