using Core;
using NUnit.Framework;

namespace Tests.CoreTests
{
	[TestFixture]
	public sealed class UndoableCommandStackTests
	{
		private UndoableCommandStack _undoStack;

		[SetUp]
		public void Setup()
		{
			_undoStack = new UndoableCommandStack(3);
		}

		[Test]
		public void PushPopTest()
		{
			var light = new Light();
			var command0 = new OnCommand(light);
			var command1 = new OnCommand(light);
			var command2 = new OnCommand(light);
			var command3 = new OnCommand(light);

			_undoStack.Push(command0);
			_undoStack.Push(command1);
			_undoStack.Push(command2);
			_undoStack.Push(command3);

			var retCommand3 = _undoStack.Pop();
			var retCommand2 = _undoStack.Pop();
			var retCommand1 = _undoStack.Pop();
			var retCommand0 = _undoStack.Pop();

			Assert.AreEqual(retCommand0, EmptyCommand.GetEmptyCommand());
			Assert.AreEqual(command1, retCommand1);
			Assert.AreEqual(command2, retCommand2);
			Assert.AreEqual(command3, retCommand3);
		}

		[Test]
		public void ClearTest()
		{
			var light = new Light();
			var command0 = new OnCommand(light);
			var command1 = new OnCommand(light);
			var command2 = new OnCommand(light);
			var command3 = new OnCommand(light);

			_undoStack.Push(command0);
			_undoStack.Push(command1);
			_undoStack.Push(command2);
			_undoStack.Push(command3);

			_undoStack.Clear();

			var ret = _undoStack.Pop();
			Assert.AreEqual(ret, EmptyCommand.GetEmptyCommand());
		}
	}
}