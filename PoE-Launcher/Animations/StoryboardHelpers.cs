using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace PoE_Launcher
{
    /// <summary>
    /// Animation helpers for storyboards
    /// </summary>
    public static class StoryboardHelpers
    {
        /// <summary>
        /// Adds a slide in from right animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">The time the animation will take in seconds</param>
        /// <param name="offset">The distance to move the element to</param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        public static void AddSlideFromRight(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f, bool keepWidth = true)
        {
            // Create the margin for the slide animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(keepWidth ? offset : 0, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the story board
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide to left animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">The time the animation will take in seconds</param>
        /// <param name="offset">The distance to move the element to</param>
        /// <param name="decelerationRatio"></param>
        /// <param name="keepWidth">True to keep the element's width the same after the animation, false to  reduce it to 0</param>
        public static void AddSlideToLeft(this Storyboard storyboard, float duration, double offset, float decelerationRatio = 0.9f, bool keepWidth = true)
        {
            // Create the margin for the slide animation
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, keepWidth ? offset : 0, 0),
                DecelerationRatio = decelerationRatio
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add this to the story board
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade in animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">The time the animation will take in seconds</param>
        public static void AddFadeIn(this Storyboard storyboard, float duration)
        {
            // Create the margin for the slide animation
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 0,
                To = 1
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the story board
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade out animation to the storyboard
        /// </summary>
        /// <param name="storyboard">The storyboard to add the animation to</param>
        /// <param name="duration">The time the animation will take in seconds</param>
        public static void AddFadeOut(this Storyboard storyboard, float duration)
        {
            // Create the margin for the slide animation
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(duration)),
                From = 1,
                To = 0
            };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add this to the story board
            storyboard.Children.Add(animation);
        }
    }
}
