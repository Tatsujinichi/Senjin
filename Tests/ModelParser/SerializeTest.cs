using System.Linq;
using Collada141;
using Core;
using NUnit.Framework;

namespace Tests.ModelParser
{
	[TestFixture]
	public class SerializeTest
	{
		[Test]
		public void TestSerialize()
		{
			var testmodel = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ModelParser\res\untitled.dae");
			Assert.NotNull(testmodel);
			byte[] bytes = testmodel.ToBytes();
		}
	}
}