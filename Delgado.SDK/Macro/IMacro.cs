using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.SDK.Macro
{
    /// <summary>
    /// A macro to be executed by a binded parameter
    /// </summary>
    public interface IMacro
    {
        /// <summary>
        /// Configures the setting of properties for the Macro
        /// </summary>
        public IMacroConfigurator Configurator { get; }
        /// <summary>
        /// Executes the macro
        /// </summary>
        public void Execute();
    }
}
