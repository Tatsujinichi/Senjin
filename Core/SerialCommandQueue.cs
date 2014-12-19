using System.Collections.Generic;

namespace Core
{
	public class SerialCommandQueue
	{
		private readonly Queue<IUndoableCommand> _commandQueue;
		private readonly UndoableCommandStack _undoQueue;

		public SerialCommandQueue(int stackDepth)
		{
			_commandQueue = new Queue<IUndoableCommand>();
			_undoQueue = new UndoableCommandStack(stackDepth);
		}

		public void EnqueueCommand(IUndoableCommand command)
		{
			_commandQueue.Enqueue(command);
		}

		private void ExecuteNextCommand()
		{
			var command = _commandQueue.Dequeue();
			command.Execute();
			_undoQueue.Push(command);
		}

		private void UndoLastCommand()
		{
			var undoCommand = _undoQueue.Pop();
			undoCommand.Undo();
		}
	}
}