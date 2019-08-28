using System;
using System.Windows;

namespace PoE_Launcher
{
    /// <summary>
    /// A base attached property to replace the vanilla WPF attached property
    /// </summary>
    /// <typeparam name="Parent">The parent class to be attached property</typeparam>
    /// <typeparam name="Property">The type of the attached property</typeparam>
    public abstract class BaseAttachedProperty<Parent, Property>
        where Parent: BaseAttachedProperty<Parent, Property>, new()
    {
        #region Public events

        /// <summary>
        /// Fired when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        /// <summary>
        /// Fired when the value is updated, even if the value stays the same
        /// </summary>
        public event Action<DependencyObject, object> ValueUpdated = (sender, value) => { };

        #endregion

        #region Public properties

        /// <summary>
        /// An instance of the parent class
        /// </summary>
        public static Parent Instance { get; private set; } = new Parent();

        #endregion

        #region Attached property definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValuePropety = DependencyProperty.RegisterAttached(
            "Value", 
            typeof(Property), 
            typeof(BaseAttachedProperty<Parent, Property>),
            new UIPropertyMetadata(
                default(Property),
                new PropertyChangedCallback(
                    OnValuePropertyChanged
                ),
                new CoerceValueCallback(OnValuePropertyUpdated)
            )
        );

        /// <summary>
        /// The callback event when the <see cref="ValuePropety"/> is changed
        /// </summary>
        /// <param name="sender">The UI element that had it's property changed</param>
        /// <param name="e">The argument for the event</param>
        private static void OnValuePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(sender, e);

            // Call event listeners
            Instance.ValueChanged(sender, e);
        }

        /// <summary>
        /// The callback event when the <see cref="ValuePropety"/> is updated
        /// This event is fired even if the value was changed in the update process
        /// </summary>
        /// <param name="sender">The UI element that had it's property changed</param>
        /// <param name="e">The argument for the event</param>
        private static object OnValuePropertyUpdated(DependencyObject sender, object value)
        {
            // Call the parent function
            Instance.OnValueUpdated(sender, value);

            // Call event listeners
            Instance.ValueUpdated(sender, value);

            // Return the value
            return value;
        }

        /// <summary>
        /// Gets the attached property
        /// </summary>
        /// <param name="sender">The UI element to get the property from</param>
        /// <returns></returns>
        public static Property GetValue(DependencyObject sender) => (Property)sender.GetValue(ValuePropety);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject sender, Property value) => sender.SetValue(ValuePropety, value);

        #endregion

        #region Event methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="d">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {  }

        /// <summary>
        /// The method that is called when any attached property of this type is updated, even if the value stays the same
        /// </summary>
        /// <param name="d">The UI element that this property was updated for</param>
        /// <param name="value">Value that was updated</param>
        public virtual void OnValueUpdated(DependencyObject d, object value) { }

        #endregion
    }
}
