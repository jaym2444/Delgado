using Delgado.SDK.Macro;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.Runtime
{
    /// <summary>
    /// A macro that can be constructed many times later on.
    /// </summary>
    public class ConstructableMacro
    {
        /// <summary>
        /// Constructs a new ConstructableMacro instance
        /// </summary>
        /// <param name="macroType">The type of the macro to be constructed</param>
        /// <param name="Linked">The plugin linked to this macro is linked to</param>
        public ConstructableMacro(Type macroType, Plugin Linked)
        {
            _macroType = macroType;
            _plugin = Linked;
            Name = macroType.Name;
        }

        private Type _macroType;
        private Plugin _plugin;
        /// <summary>
        /// The name of the macro
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// The plugin the macro is associated with
        /// </summary>
        public Plugin Plugin { get => _plugin; }
        /// <summary>
        /// Constructs a macro defined by a plugin
        /// </summary>
        /// <returns>The macro constructed</returns>
        public IMacro Construct()
        {
            return (IMacro)Activator.CreateInstance(_macroType);
        }
    }
}
