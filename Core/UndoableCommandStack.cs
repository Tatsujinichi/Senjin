using System.Collections.Generic;

namespace Core
{
	public sealed class UndoableCommandStack
	{
		private readonly LinkedList<IUndoableCommand> _commands = new LinkedList<IUndoableCommand>();
		private readonly int _maxDepth;

		public UndoableCommandStack(int maxDepth)
		{
			_maxDepth = maxDepth;
		}

		public void Push(IUndoableCommand command)
		{
			if (_commands.Count >= _maxDepth)
				_commands.RemoveLast();
			_commands.AddFirst(command);
		}

		public IUndoableCommand Pop()
		{
			IUndoableCommand first = _commands.First.Value;
			_commands.RemoveFirst();
			return first;
		}

		public void Clear()
		{
			_commands.Clear();
		}
	}
}