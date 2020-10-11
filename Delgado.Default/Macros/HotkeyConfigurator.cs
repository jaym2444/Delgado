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
            ConfigurationFields = new MacroConfigurationField<IMacroConfigurationField>[] { 
                new MacroConfigurationField<TextboxField>(""),
            };
        }

        public IMacro Macro {get;}

        public MacroConfigurationField<IMacroConfigurationField>[] ConfigurationFields { get; }

        public void Configure(MacroConfigurationField<IMacroConfigurationField>[] results)
        {
            throw new NotImplementedException();
        }
    }
}
