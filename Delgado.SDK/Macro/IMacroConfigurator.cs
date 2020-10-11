using Delgado.SDK.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.SDK.Macro
{
    /// <summary>
    /// Configures a macro for use.
    /// </summary>
    public interface IMacroConfigurator
    {
        /// <summary>
        /// The fields that provide the configuration data
        /// </summary>
        public MacroConfigurationField<IMacroConfigurationField>[] ConfigurationFields { get; }
        /// <summary>
        /// Configures a linked macro
        /// </summary>
        public void Configure(MacroConfigurationField<IMacroConfigurationField>[] results);
        /// <summary>
        /// The linked macro
        /// </summary>
        public IMacro Macro { get; }
    }
}
