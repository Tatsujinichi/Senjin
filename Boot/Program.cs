using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelParser;

namespace Boot
{
	class Program
	{
		static void Main(string[] args)
		{
			var testmodel = Parser.Load(@"C:\dev\Senjin\ColladaReader\res\untitled.dae");
		}
	}
}
