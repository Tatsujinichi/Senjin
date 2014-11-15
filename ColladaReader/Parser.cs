using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Collada141;

namespace ModelParser
{
    public static class Parser
    {
	    public static COLLADA Load(string path)
	    {
			//C:\dev\Senjin\ColladaReader\res\untitled.dae
		    using (var xmlReader = XmlReader.Create(path))
		    {
			    var serializer = new XmlSerializer(typeof (COLLADA));
				return (COLLADA)serializer.Deserialize(xmlReader);
		    }
	    }
    }
}
