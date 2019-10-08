using PoE_Launcher.Core;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace PoE_Launcher
{
    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        /// <summary>
        /// Register <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            // If we are in designer mode, show the current page
            // as the dependency property does not fire
            if (DesignerProperties.GetIsInDesignMode(this))
                NewPage.Content = (BasePage)ApplicationPageConverter.Instance.Convert(IoC.Get<ApplicationViewModel>().CurrentPage);
        }

        #endregion

        #region Property Changed events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> property changes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void CurrentPagePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frames
            var newPageFrame = (sender as PageHost).NewPage;
            var oldPageFrame = (sender as PageHost).OldPage;

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from the frame
            newPageFrame.Content = null;

            // Move the previous page into the old page frame
            oldPageFrame.Content = oldPageContent;

            // Animate out previous page when the Loaded event fires
            // right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                // Without awaiting for the animation to finish
                oldPage.ShouldAnimateOut = true;

                // Once it is done, remove the old page
                Task.Delay((int)oldPage.SlideSeconds * 1000).ContinueWith((t) =>
                {
                    // Jump back to the UI thread and remove the old page
                    Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                });
            }
            // Set the new page content
            newPageFrame.Content = e.NewValue;
        }

        #endregion
    }
}
