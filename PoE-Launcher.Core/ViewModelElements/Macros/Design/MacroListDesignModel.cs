using System.Collections.Generic;

namespace PoE_Launcher.Core
{
    public class MacroListDesignModel : MacroListViewModel
    {
        #region Singleton

        public static MacroListDesignModel Instance => new MacroListDesignModel();

        #endregion

        #region Constructor

        public MacroListDesignModel()
        {
            Items = new List<MacroListItemViewModel>
            {
                new MacroListItemDesignModel
                {
                    Name = "Trade Macro",
                    FullPath = "E:\\PoE Macros\\TradeMacro.ahk"
                },
                new MacroListItemDesignModel
                {
                    Name = "Logout Macro",
                    FullPath = "E:\\PoE Macros\\SomeSubFolder\\LogoutMacro.ahk"
                },
                new MacroListItemDesignModel
                {
                    Name = "Mercury Trade",
                    FullPath = "E:\\PoE Macros\\mercury.jar"
                },
                new MacroListItemDesignModel
                {
                    Name = "LabCompass",
                    FullPath = "E:\\PoE Macros\\Compass\\Sub\\Folder\\Really Long Path To Test Stuff\\LabCompass.ahk"
                },
            };

        }

        #endregion
    }
}
