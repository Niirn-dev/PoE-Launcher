using System.Windows.Controls;
using System.Windows;
using System.Threading.Tasks;

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
            get
            {
                return mViewModel;
            }
            set
            {
                // If nothing has changed, return
                if (value == mViewModel)
                    return;

                // Update the view model
                mViewModel = value;

                // Update data context for the page
                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage()
        {
            this.ViewModel = new VM();

            // If we are animating...
            if (this.PageLoadAnimation != PageAnimation.None)
                // Hide to begin with
                this.Visibility = Visibility.Collapsed;

            // Listen out for the page loading
            this.Loaded += BasePage_Loaded;

            this.Unloaded += BasePage_Unloaded;
        }

        #endregion

        #region Animation Load / Unload

        /// <summary>
        /// Once the page is loaded play any required animation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // Animate the page in
            await AnimateIn();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
                return;

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromTheRight:
                    // Start the animation
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);

                    break;
            }
        }

        /// <summary>
        /// Once the page is unloaded play any required animations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BasePage_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await AnimateOut();
        }

        /// <summary>
        /// Animates this page in
        /// </summary>
        /// <returns></returns>
        public async Task AnimateOut()
        {
            if (this.PageUnloadAnimation == PageAnimation.None)
                return;

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToTheLeft:
                    // Start the animation
                    await this.SlideAndFadeOutToTheLeft(this.SlideSeconds);

                    break;
            }
        }

        #endregion
    }
}
