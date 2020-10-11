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
        public IMacroConfigurationField<object>[] ConfigurationFields { get; }
        /// <summary>
        /// Configures a linked macro
        /// </summary>
        public void Configure(IMacroConfigurationField<object>[] results);
        /// <summary>
        /// The linked macro
        /// </summary>
        public IMacro Macro { get; }
    }
}
