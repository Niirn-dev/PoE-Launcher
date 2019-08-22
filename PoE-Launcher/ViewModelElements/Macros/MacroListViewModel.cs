using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace PoE_Launcher
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
