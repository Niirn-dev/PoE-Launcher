using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace PoE_Launcher
{
    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        /// <summary>
        /// Slide from the right and fade in animation
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="duration">Animation duration in seconds</param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        /// <param name="width">Width of the element to animate to. If left as 0 uses element's Actual Width property instead</param>
        /// <returns></returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float duration = 0.3f, bool keepWidth = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide from right animation
            sb.AddSlideFromRight(duration, width == 0 ? element.ActualWidth : width, keepWidth: keepWidth);

            // Add fade in animation
            sb.AddFadeIn(duration);

            // Start animating
            sb.Begin(element);

            // Make page visible
            element.Visibility = Visibility.Visible;

            // Wait for animation to finish
            await Task.Delay((int)duration * 1000);
        }

        /// <summary>
        /// Slide out to left and fade out animation
        /// </summary>
        /// <param name="element">Element to animate</param>
        /// <param name="duration">Animation duration in seconds</param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        /// <param name="width">Width of the element to animate to. If left as 0 uses element's Actual Width property instead</param>
        /// <returns></returns>
        public static async Task SlideAndFadeOutToTheLeftAsync(this FrameworkElement element, float duration, bool keepWidth = true, int width = 0)
        {
            // Create the storyboard
            var sb = new Storyboard();

            // Add slide to left animation
            sb.AddSlideToLeft(duration, width == 0 ? element.ActualWidth : width, keepWidth: keepWidth);

            // Add fade out animation
            sb.AddFadeOut(duration);

            // Start animating
            sb.Begin(element);

            // Wait for animation to finish
            await Task.Delay((int)duration * 1000);
        }
    }
}
