using System;
using System.Collections.Generic;
using ChainOfCommand;
using NUnit.Framework;
using Rhino.Mocks;

namespace Example.Test
{
	[TestFixture]
	public class SearchEngineTest
	{
		[Test]
		public void ExecuteSearch_NullArgument_ThrowsException()
		{
			// Arrange
			var mocks = new MockRepository();
			var host = mocks.DynamicMock<IHost>();
			var searchEngine = new SearchEngine(host);

			// Act, Assert
			Assert.Throws<ArgumentNullException>(() => searchEngine.ExecuteSearch(null));
		}

		[Test]
		public void ExecuteSearch_ValidArgument_ReturnsResult()
		{
			// Arrange
			var mocks = new MockRepository();
			var host = mocks.DynamicMock<IHost>();
			var expectedResult = new SearchResult(5);
			host.Expect(h => h.Execute(null)).IgnoreArguments().Return(expectedResult);
			var searchEngine = new SearchEngine(host);
			var searchTerms = new Dictionary<string, string>();
			mocks.ReplayAll();

			// Act
			var searchResult = searchEngine.ExecuteSearch(searchTerms);

			// Assert
			Assert.AreSame(expectedResult, searchResult);
			mocks.VerifyAll();
		}

		[Test]
		public void ExecuteSearch_InvalidArgument_ThrowsException()
		{
			// Arrange
			var mocks = new MockRepository();
			var host = mocks.DynamicMock<IHost>();
			var expectedResult = new ErrorResult("test");
			host.Expect(h => h.Execute(null)).IgnoreArguments().Return(expectedResult);
			var searchEngine = new SearchEngine(host);
			var searchTerms = new Dictionary<string, string>();
			mocks.ReplayAll();

			// Act, Assert
			Assert.Throws<Exception>(() => searchEngine.ExecuteSearch(searchTerms), "test");
			mocks.VerifyAll();
		}
	}
}
