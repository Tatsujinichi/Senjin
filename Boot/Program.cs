using System.Linq;
using Audio;
using DryIoc;
using Engine;
using Input;
using Network;
using Visual;

namespace Boot
{
	internal static class Program
	{
		private static void Main(string[] args)
		{
			var container = new Container();
			container.Register<IVisualService, DummyVisualService>();
			container.Register<IAudioService, DummyAudioService>();
			container.Register<INetworkService, DummyNetworkService>();
			container.Register<IInputService, DummyInputService>();

			container.Register<GameEngine>();

			var gameEngine = container.Resolve<GameEngine>();
		}
	}
}