using System;
using System.Windows;

namespace PoE_Launcher
{
    /// <summary>
    /// A base class to run any animation method when a boolean is set to true
    /// and a reverse animation when it is set to false
    /// </summary>
    /// <typeparam name="Parent"></typeparam>
    public abstract class AnimateBaseProperty<Parent> : BaseAttachedProperty<Parent, bool>
        where Parent: BaseAttachedProperty<Parent, bool>, new()
    {
        #region Public properties

        public bool IsFirstLoad { get; set; } = true;

        #endregion

        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            // Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if (sender.GetValue(ValuePropety) == value && !IsFirstLoad)
                return;

            // On first load...
            if (IsFirstLoad)
            {
                // Create single self-unhookable event for the element loading event
                // The event will only fire once
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do desired animation
                    DoAnimation(element, (bool)value);

                    // First load was compleded
                    IsFirstLoad = false;
                };

                // Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else
                // Do the animation
                DoAnimation(element, (bool)value);
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The UI element</param>
        /// <param name="value">The new value</param>
        protected virtual void DoAnimation(FrameworkElement element, bool value)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Animates a framewoek element sliding in from the left side on show
    /// and sliding out to the left side on hide
    /// </summary>
    public class AnimateSlideLeftSideProperty : AnimateBaseProperty<AnimateSlideLeftSideProperty>
    {
        protected override void DoAnimation(FrameworkElement element, bool value)
        {
            if (value)
            {
                // Animate in
            }
            else
            {
                // Animate out
            }
        }
    }
}
