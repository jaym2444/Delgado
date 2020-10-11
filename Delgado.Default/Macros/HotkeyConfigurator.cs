using Delgado.SDK.Fields;
using Delgado.SDK.Macro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Default.Macros
{
    public class HotkeyConfigurator : IMacroConfigurator
    {
        public HotkeyConfigurator(IMacro macro)
        {
            Macro = macro;
            ConfigurationFields = new IMacroConfigurationField<object>[1];
            ConfigurationFields[0] = new MacroConfigurationField<TextboxField>("Random Text Here");
        }

        public IMacro Macro {get;}

        public IMacroConfigurationField<object>[] ConfigurationFields { get; }

        public void Configure(IMacroConfigurationField<object>[] results)
        {
            
        }
    }
}
