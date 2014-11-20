using Collada141;
using Microsoft.Xna.Framework.Content.Pipeline;
using ModelParser;

namespace ColladaPipelineExtension
{
	[ContentImporter(".dae", DefaultProcessor = "ColladaContentProcessor", DisplayName = "dae Importer")]
	public sealed class ColladaImporter : ContentImporter<COLLADA>
	{
		public override COLLADA Import(string filename, ContentImporterContext context)
		{
			return XmlHelper.Load<COLLADA>(filename);
		}
	}
}