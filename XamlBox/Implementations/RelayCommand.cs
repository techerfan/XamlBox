using System;
using System.Security.Policy;
using System.Windows.Input;

namespace XamlBox.Implementations
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        /// <summary>
        /// The action to run
        /// </summary>
        private Action _mAction;

        /// <summary>
        /// Specifies if the command can execute
        /// </summary>
        private bool _canExecute;

        #endregion

        #region Public Events

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor to only specify the action
        /// </summary>
        /// <param name="action"></param>
        public RelayCommand(Action action)
        {
            _mAction = action;

            // set canExecute to true by default
            _canExecute = true;
        }

        /// <summary>
        /// Specifying both action and canExecute
        /// </summary>
        /// <param name="action"></param>
        /// <param name="canExecute"></param>
        public RelayCommand(Action action, bool canExecute)
        {
            _mAction = action;
            _canExecute = canExecute;
        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Specifies whether the command can be executed or not
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        /// <summary>
        /// Executes the action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _mAction();
        }

        #endregion
    }
}
