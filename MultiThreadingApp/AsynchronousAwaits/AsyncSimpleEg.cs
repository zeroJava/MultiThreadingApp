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

			TaskAwaiter<int> awaiter = BigNumberCountAsync(500000).GetAwaiter();
			//Console.WriteLine(awaiter.GetResult());

			Console.WriteLine("Finshed");
		}

		private async Task<int> BigNumberCountAsync(int limit)
		{
			Console.WriteLine("Limit: " + limit);

			int count = 0;

			await GetBigNumber(limit).ContinueWith(rt =>
			{
				if (rt.Status == TaskStatus.RanToCompletion)
				{
					Console.WriteLine("Number generated");

					BigInteger bigInteger = rt.Result;
					count = bigInteger.ToString().Length;
					
					Console.WriteLine("Count: " + count);
				}
				else if (rt.Status == TaskStatus.Faulted)
				{
					Console.WriteLine(rt.Exception.GetBaseException().Message);
				}
			});

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