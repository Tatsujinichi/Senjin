using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParser;
using NUnit.Framework;

namespace Tests.ModelParser
{
	[TestFixture]
	class BinaryHelperTests
	{
		[Test]
		public void ToObject()
		{
			var testData = new TestData
			{
				Name = "john",
				Ints = new List<int> {1, 2, 3},
				NestedTestData = new TestData
				{
					Name = "nestedName",
					Ints = new List<int> {4, 5, 6},
					NestedTestData = new TestData()
				}
			};
			var bytes = testData.ToBytes();
			var obj = bytes.ToObject<TestData>();
			Assert.AreEqual(testData.Name, obj.Name);
			Assert.True(testData.Ints.SequenceEqual(obj.Ints));
			Assert.AreEqual(testData.NestedTestData.Name, obj.NestedTestData.Name);
			Assert.True(testData.NestedTestData.Ints.SequenceEqual(obj.NestedTestData.Ints));
		}

		[Test]
		public void ToBytes()
		{
			var testData = new TestData
			{
				Name = "john",
				Ints = new List<int> { 1, 2, 3 },
				NestedTestData = new TestData
				{
					Name = "nestedName",
					Ints = new List<int> { 4, 5, 6 },
					NestedTestData = new TestData()
				}
			};
			var testData2 = new TestData
			{
				Name = "john",
				Ints = new List<int> { 1, 2, 3 },
				NestedTestData = new TestData
				{
					Name = "nestedName",
					Ints = new List<int> { 4, 5, 6 },
					NestedTestData = new TestData()
				}
			};
			var bytes1 = testData.ToBytes();
			var bytes2 = testData2.ToBytes();

			Assert.True(bytes1.SequenceEqual(bytes2));
		}

		[Serializable]
		private class TestData
		{
			public string Name { get; set; }
			public List<int> Ints { get; set; }
			public TestData NestedTestData { get; set; }
		}
	}
}
