using System;
using Ninject;

namespace PoE_Launcher.Core
{


    /// <summary>
    /// The Inversion of Control container for the application
    /// </summary>
    public static class IoC
    {
        #region Public properties

        /// <summary>
        /// The kernel for the IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        #endregion


        #region Construction

        /// <summary>
        /// Sets up the IoC container, binds all information required and is ready for use
        /// Must be called as soon as the application starts up to ensure all services can be found
        /// </summary>
        public static void Setup()
        {
            // Bind all required view model
            BindModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindModels()
        {
            // Binds to a single instance of the ApplicationViewModel
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        #endregion

        /// <summary>
        /// Gets a service from the IoC of the specified type
        /// </summary>
        /// <typeparam name="T">The type to get</typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
