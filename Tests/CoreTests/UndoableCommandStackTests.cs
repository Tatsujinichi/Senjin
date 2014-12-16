using System;
using Core;
using NUnit.Framework;

namespace Tests.CoreTests
{
	[TestFixture]
	public sealed class UndoableCommandStackTests
	{
		[SetUp]
		public void Setup()
		{
	
		}

		[Test]
		public void PushTest()
		{
			
		}

		[Test]
		public void PopTest()
		{
			
		}

		[Test]
		public void ClearTest()
		{
			
		}

		private class LightSwitch
		{
			private readonly IUndoableCommand _onCommand;
			private readonly IUndoableCommand _offCommand;
			private readonly UndoableCommandStack _undoCommandStack;

			public LightSwitch(IUndoableCommand onCommand, IUndoableCommand offCommand)
			{
				_onCommand = onCommand;
				_offCommand = offCommand;
				_undoCommandStack = new UndoableCommandStack(4);
			}

			public void TurnSwitchOn()
			{
				_onCommand.Execute();
			}

			public void TurnSwitchOff()
			{
				_offCommand.Execute();
			}

			public void Undo()
			{
				IUndoableCommand lastCommand = _undoCommandStack.Pop();
				lastCommand.Undo();
			}

			public void Reset()
			{
				_offCommand.Execute();
				_undoCommandStack.Clear();
			}
		}

		private sealed class OnCommand : IUndoableCommand
		{
			private readonly ISwitchable _target;
			private bool _previousState;

			public OnCommand(ISwitchable target)
			{
				_target = target;
			}

			public void Execute()
			{
				_previousState = _target.GetState();
				_target.On();
			}

			public void Undo()
			{
				if (_previousState == false)
				{
					_target.Off();
				}
				else
				{
					_target.On();
				}
			}
		}

		private sealed class OffCommand : IUndoableCommand
		{
			private readonly ISwitchable _target;
			private bool _previousState;

			public OffCommand(ISwitchable target)
			{
				_target = target;
			}

			public void Execute()
			{
				_previousState = _target.GetState();
				_target.Off();
			}

			public void Undo()
			{
				if (_previousState == true)
				{
					_target.Off();
				}
				else
				{
					_target.On();
				}
			}
		}

		private interface ISwitchable
		{
			void On();
			void Off();
			bool GetState();
		}

		private sealed class Light : ISwitchable
		{
			private bool _isOn;

			public bool GetState()
			{
				return _isOn;
			}

			public void On()
			{
				_isOn = true;
			}

			public void Off()
			{
				_isOn = false;
			}
		}
	}
}