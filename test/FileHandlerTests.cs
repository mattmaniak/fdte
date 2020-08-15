using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using fdte;

namespace fdteTest
{
	[TestClass]
	public class FileHandlerTest
	{
		[TestMethod]
		public void ReadTest()
		{
			const string basename = "fdte.txt";
			File.Create(basename);
			Assert.AreNotEqual(FileHandler.Read(basename), null);
		}
	}
}
