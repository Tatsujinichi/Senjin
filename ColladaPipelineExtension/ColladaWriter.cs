using System;
using Collada141;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using ModelParser;

namespace ColladaPipelineExtension
{
	[ContentTypeWriter]
	public sealed class ColladaWriter : ContentTypeWriter<COLLADA>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			//return "ColladaPipelineExtension.ColladaReader, ColladaPipelineExtension, Version=1.0.0.0, Culture=neutral";
			//return "Collada141.COLLADA, ModelParser, Version=1.0.0.0, Culture=neutral";
			
			//ContentTypeReader ColladaPipelineExtension.ColladaReader, ColladaPipelineExtension, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null.
			return "WindowsGame.ColladaReader, WindowsGame, Version=1.0.0.0, Culture=neutral";
			//return "ColladaPipelineExtension.ColladaReader, ColladaPipelineExtension, Version=1.0.0.0, Culture=neutral";
		}

		protected override void Write(ContentWriter output, COLLADA value)
		{
			//output.Write(value.ToBytes());
			output.WriteRawObject(value);
		}
	}
}