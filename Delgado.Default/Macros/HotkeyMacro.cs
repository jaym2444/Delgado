using Delgado.SDK.Macro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Default.Macros
{
    [Macro]
    public class HotkeyMacro : IMacro
    {
        internal string Text;
        public HotkeyMacro()
        {
            Configurator = new HotkeyConfigurator(this);
        }
        public IMacroConfigurator Configurator { get; }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
