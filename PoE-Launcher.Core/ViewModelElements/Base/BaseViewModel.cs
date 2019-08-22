using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// Base class for view model
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any property changes it's value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #region Command helpers

        /// <summary>
        /// Runs a command if the updating flag is not set.
        /// Sets the flag while the command is executing.
        /// Resets the flag on exit from the function (once finished or if the exception occurred)
        /// </summary>
        /// <param name="updatingFlag">The boolean property flag defining if the command is already running</param>
        /// <param name="action">the action to run if it's not already running</param>
        /// <returns></returns>
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            // Check if the function is already running
            if (updatingFlag.GetPropertyType())
                return;

            // Set the property flag to true to indicate that the flag is running
            updatingFlag.SetPropertyValue(true);

            try
            {
                // Run the passed action
                await action();
            }
            finally
            {
                // Set the property flag back to false
                updatingFlag.SetPropertyValue(false);
            }
        }

        #endregion
    }
}
