using System.IO;
using System.Linq;
using Collada141;
using Core;
using NUnit.Framework;

namespace Tests.ModelParser
{
	[TestFixture]
	public class XmlHelperTests
	{
		[Test]
		public void Load()
		{
			var testmodel = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ModelParser\res\untitled.dae");
			Assert.NotNull(testmodel);
		}

		[Test]
		public void Save()
		{
			try
			{
				var testmodel = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ModelParser\res\untitled.dae");
				Assert.NotNull(testmodel);

				XmlHelper.Save(@"C:\dev\Senjin\ModelParser\res\untitled2.dae", testmodel);

				var testmodel2 = XmlHelper.Load<COLLADA>(@"C:\dev\Senjin\ModelParser\res\untitled2.dae");

				//TODO: add more
				var f1 = (library_cameras)testmodel.Items.First();
				var f2 = (library_cameras)testmodel2.Items.First();
				Assert.AreEqual(f1.id, f2.id);
			}
			finally
			{
				File.Delete(@"C:\dev\Senjin\ModelParser\res\untitled2.dae");
			}
		}
	}
}