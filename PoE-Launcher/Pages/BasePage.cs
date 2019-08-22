using PoE_Launcher.Core;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PoE_Launcher
{
    /// <summary>
    /// Base page for all pager to inherit base functionality
    /// </summary>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()
    {
        #region Private members

        /// <summary>
        /// View model associated with this page
        /// </summary>
        private VM mViewModel;

        #endregion

        #region Public properties

        /// <summary>
        /// The animation to play when the page is loaded
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromTheRight;

        /// <summary>
        /// The animation to play when the page is unloaded
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToTheLeft;

        /// <summary>
        /// The time it takes for animation to complete
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;

        /// <summary>
        /// View model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get => mViewModel;

            set
            {
                // If nothing has changed, return
                if (value == mViewModel)
                    return;

                // Update the view model
                mViewModel = value;

                // Update data context for the page
                DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            ViewModel = new VM();

            // If we are animating...
            if (PageLoadAnimation != PageAnimation.None)
                // Hide to begin with
                Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            Loaded += BasePage_LoadedAsync;

            Unloaded += BasePage_UnloadedAsync;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded play any required animation
        /// Kept as async to make sure we're on the UI thread when changing the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            // Animate the page in
            await AnimateInAsync();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
                return;

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromTheRight:
                    // Start the animation
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Once the page is unloaded play any required animations
        /// Kept as async to make sure we're on the UI thread when changing the UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_UnloadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateOutAsync();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOutAsync()
        {
            if (PageUnloadAnimation == PageAnimation.None)
                return;

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToTheLeft:
                    // Start the animation
                    await this.SlideAndFadeOutToTheLeftAsync(SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
