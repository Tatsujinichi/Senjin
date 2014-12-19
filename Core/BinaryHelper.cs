using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Core
{
	public static class Extensions
	{
		public static T ToObject<T>(this byte[] bytes)
		{
			T obj;
			var binaryFormatter = new BinaryFormatter();
			using (var ms = new MemoryStream(bytes))
			{
				obj = (T)binaryFormatter.Deserialize(ms);
			}
			return obj;
		}

		public static byte[] ToBytes(this object obj)
		{
			byte[] bytes;
			var binaryFormatter = new BinaryFormatter();
			using (var ms = new MemoryStream())
			{
				binaryFormatter.Serialize(ms, obj);
				bytes = ms.ToArray();
			}
			return bytes;
		}
	}
}