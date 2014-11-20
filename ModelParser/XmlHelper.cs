using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Collada141;

namespace ModelParser
{
    public static class XmlHelper
    {
	    public static T Load<T>(string path)
	    {
		    using (var xmlReader = XmlReader.Create(path))
		    {
				var serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(xmlReader);
		    }
	    }

	    public static void Save<T>(string path, T obj)
	    {
			using (var xmlWriter = XmlWriter.Create(path))
			{
				var serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(xmlWriter, obj);
			}
	    }
    }
}
