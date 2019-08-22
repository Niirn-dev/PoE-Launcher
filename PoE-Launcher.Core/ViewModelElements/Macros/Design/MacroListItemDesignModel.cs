namespace PoE_Launcher.Core
{
    /// <summary>
    /// The design -time data for a <see cref="MacroListItemViewModel"/>
    /// </summary>
    public class MacroListItemDesignModel : MacroListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance of the design model
        /// </summary>
        public static MacroListItemDesignModel Instance => new MacroListItemDesignModel();

        #endregion

        #region Constractor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MacroListItemDesignModel()
        {
            Name = "Macro name";
            FullPath = "E:\\PoE Macros\\SomeMacro.ahk";
        }

        #endregion
    }
}
