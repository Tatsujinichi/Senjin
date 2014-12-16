using System;


namespace Core
{
	public interface IUndoableCommand : ICommand
	{
		void Undo();
	}
}