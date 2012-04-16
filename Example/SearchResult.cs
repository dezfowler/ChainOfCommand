using System;
using ChainOfCommand;

namespace Example
{
	public class SearchResult : IResult
	{
		public int Sum { get; private set; }

		public SearchResult(int sum)
		{
			Sum = sum;
		}
	}
}