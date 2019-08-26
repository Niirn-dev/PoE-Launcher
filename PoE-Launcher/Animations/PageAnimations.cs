using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PoE_Launcher
{
    /// <summary>
    /// Helpers to animate pages
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// Slide from the right and fade in animation
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="duration">Animation duration in seconds</param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this Page page, float duration, bool keepWidth = true)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromRight(duration, page.WindowWidth, keepWidth: keepWidth);

            // Add fade in animation
            sb.AddFadeIn(duration);

            // Start animating
            sb.Begin(page);

            // Make page visible
            page.Visibility = Visibility.Visible;

            // Wait for animation to finish
            await Task.Delay((int)duration * 1000);
        }

        /// <summary>
        /// Slide out to left and fade out animation
        /// </summary>
        /// <param name="page">Page to animate</param>
        /// <param name="duration">Animation duration in seconds</param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToTheLeftAsync(this Page page, float duration, bool keepWidth = true)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide to left animation
            sb.AddSlideToLeft(duration, page.ActualWidth, keepWidth: keepWidth);

            // Add fade out animation
            sb.AddFadeOut(duration);

            // Start animating
            sb.Begin(page);

            // Wait for animation to finish
            await Task.Delay((int)duration * 1000);
        }
    }
}
