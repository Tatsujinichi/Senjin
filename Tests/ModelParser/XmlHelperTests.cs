using System.Linq;
using Collada141;
using ModelParser;
using NUnit.Framework;


namespace Tests
{
	[TestFixture]
	public class XmlHelperTests
	{
		[Test]
		public void Load()
		{
			var testmodel = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ColladaReader\res\untitled.dae");
			Assert.NotNull(testmodel);
		}

		[Test]
		public void Save()
		{
			var testmodel = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ColladaReader\res\untitled.dae");
			Assert.NotNull(testmodel);

			XmlHelper.Save(@"C:\dev\Senjin\ColladaReader\res\untitled2.dae", testmodel);

			var testmodel2 = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ColladaReader\res\untitled2.dae");

			//TODO: add more
			var f1 = (library_cameras)testmodel.Items.First();
			var f2 = (library_cameras)testmodel2.Items.First();
			Assert.AreEqual(f1.id, f2.id);
		}
	}
}