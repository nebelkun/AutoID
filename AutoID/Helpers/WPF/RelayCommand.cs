using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace AutoID.Helpers.WPF
{
	public delegate bool PredicateDelegate();
	public class RelayCommand : ICommand
	{
		#region Fields
		readonly Action _execute;
		readonly Predicate<object> _canExecute;
		#endregion

		#region Ctors

		public RelayCommand(Action execute, Predicate<object> canExecute = null)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			_execute = execute;
			_canExecute = canExecute;
		}

		public RelayCommand(Action execute, PredicateDelegate canExecute)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			_execute = execute;
			_canExecute = obj => canExecute();
		}
		#endregion

		public void Execute()
		{
			if (CanExecute(null))
				ForceExecute();
		}

		[DebuggerStepThrough]
		public void ForceExecute()
		{
			try
			{
				_execute();
			}
			catch (Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}

		#region ICommand Members

		[DebuggerStepThrough]
		void ICommand.Execute(object parameter)
		{
			ForceExecute();
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
			{
				try
				{
					return _canExecute(parameter);
				}
				catch (Exception)
				{
					return false;
				}
			}
			return true;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		#endregion
	}

	public class RelayCommand<T> : ICommand
	{
		#region Fields

		readonly Action<T> _execute;
		readonly Predicate<T> _canExecute;

		#endregion

		#region Ctors

		public RelayCommand(Action<T> execute, Predicate<T> canExecute = null)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			_execute = execute;
			_canExecute = canExecute;
		}

		#endregion

		public void Execute(T parameter)
		{
			if (CanExecute(parameter))
				ForceExecute(parameter);
		}

		[DebuggerStepThrough]
		public void ForceExecute(T parameter)
		{
			try
			{
				_execute(parameter);
			}
			catch (Exception e)
			{
				System.Diagnostics.Debug.WriteLine("RelayCommand exception: " + e.Message);
			}
		}

		#region ICommand Members

		[DebuggerStepThrough]
		void ICommand.Execute(object parameter)
		{
			ForceExecute((T)parameter);
		}

		[DebuggerStepThrough]
		public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
				return _canExecute((T)(parameter ?? default(T)));
			return true;
		}

		event EventHandler ICommand.CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}
		#endregion
	}
}