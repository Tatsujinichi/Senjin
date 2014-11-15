using ModelParser;
using NUnit.Framework;


namespace Tests
{
	[TestFixture]
	public class TestParser
	{
		[Test]
		public void FirstTest()
		{
			var testmodel = Parser.Load(@"C:\dev\Senjin\ColladaReader\res\untitled.dae");
			Assert.NotNull(testmodel);
		}
	}
}