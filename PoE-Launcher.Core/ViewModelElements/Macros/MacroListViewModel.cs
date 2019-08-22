using System.Collections.Generic;

namespace PoE_Launcher.Core
{
    /// <summary>
    /// View model for each macro list item
    /// </summary>
    public class MacroListViewModel : BaseViewModel
    {
        #region Public properties

        public List<MacroListItemViewModel> Items { get; set; }

        #endregion
    }
}
