using PoE_Launcher.Core;
using System.Windows;
using System.Windows.Input;

namespace PoE_Launcher
{
    /// <summary>
    /// View model for the custom window
    /// </summary>
    public class WindowViewModel : BaseViewModel
    {
        #region Private members

        /// <summary>
        /// The window this view model controls
        /// </summary>
        private Window mWindow;

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        private int mOuterMarginSize = 10;

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        private int mWindowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mDockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Public properties

        /// <summary>
        /// Minimal width of the window
        /// </summary>
        public double WindowMinimumWidth { get; set; } = 300;

        /// <summary>
        /// Minimum height of the window
        /// </summary>
        public double WindowMinimumHeight { get; set; } = 300;

        /// <summary>
        /// True if the window should be borderless
        /// </summary>
        public bool IsBorderless => (mWindow.WindowState == WindowState.Maximized || mDockPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder => IsBorderless ? 0 : 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            // Return nothing if window is borderless to fill whole screen
            get => IsBorderless ? 0 : mOuterMarginSize;

            set => mOuterMarginSize = value;
        }

        /// <summary>
        /// Thickness value of the margin around the window
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public int WindowRadius
        {
            // Return nothing if window is borderless to fill whole screen
            get => IsBorderless ? 0 : mWindowRadius;

            set => mWindowRadius = value;
        }

        /// <summary>
        /// The radius of the edges of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// Height of the title bar / caption of the window
        /// </summary>
        public int TitleHeight { get; set; } = 36;

        /// <summary>
        /// Grid length for the title / caption of the window
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// Padding for the content of the window
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the system menu of the window
        /// </summary>
        public ICommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window">The window for view model to control</param>
        public WindowViewModel(Window window)
        {
            mWindow = window;

            // Listen out for the window resizing
            mWindow.SizeChanged += (sender, e) =>
            {
                // Fire off events for all properties that are affected by a resize
                WindowResizedEvents();
            };

            // Create commands
            MinimizeCommand = new RelayCommand(() => { mWindow.WindowState = WindowState.Minimized; });
            MaximizeCommand = new RelayCommand(() => { mWindow.WindowState ^= WindowState.Maximized; });
            CloseCommand = new RelayCommand(() => { mWindow.Close(); });
            MenuCommand = new RelayCommand(() => { SystemCommands.ShowSystemMenu(mWindow, mWindow.PointToScreen(Mouse.GetPosition(mWindow))); });

            // Fix window resize issue that arises with WindowStyle="None". Breaks the MinimumWidth/Height properties of the window
            var resizer = new WindowResizer(mWindow);

            // Listen out for dock changes
            resizer.WindowDockChanged += (dock) =>
            {
                // Store last dock position
                mDockPosition = dock;

                // Fire off resize events
                WindowResizedEvents();
            };
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Events to be fired when window is resized
        /// </summary>
        private void WindowResizedEvents()
        {
            OnPropertyChanged(nameof(IsBorderless));
            OnPropertyChanged(nameof(ResizeBorderThickness));
            OnPropertyChanged(nameof(OuterMarginSize));
            OnPropertyChanged(nameof(OuterMarginSizeThickness));
            OnPropertyChanged(nameof(WindowRadius));
            OnPropertyChanged(nameof(WindowCornerRadius));
        }

        #endregion
    }
}
