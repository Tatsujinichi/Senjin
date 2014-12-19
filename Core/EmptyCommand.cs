using System;

namespace Core
{
	public sealed class EmptyCommand : IUndoableCommand
	{
		private static readonly EmptyCommand Singleton = new EmptyCommand();

		public static EmptyCommand GetEmptyCommand()
		{
			return Singleton;
		}

		public void Execute()
		{
			
		}

		public void Undo()
		{
			
		}
	}
}