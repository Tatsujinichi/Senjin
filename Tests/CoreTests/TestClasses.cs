using Core;

namespace Tests.CoreTests
{
	public class LightSwitch
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

	public sealed class OnCommand : IUndoableCommand
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

	public sealed class OffCommand : IUndoableCommand
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

	public interface ISwitchable
	{
		void On();
		void Off();
		bool GetState();
	}

	public sealed class Light : ISwitchable
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