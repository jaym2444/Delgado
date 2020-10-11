using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.SDK.Fields
{
    /// <summary>
    /// A field that is used to configure macros
    /// </summary>
    public interface IMacroConfigurationField<out T>
    {
        /// <summary>
        /// The name of the macro
        /// </summary>
        public string Name { get; }

        /// The value of the macro
        /// </summary>
        public T Value { get; }
        /// <summary>
        /// Evaluates whether this configuration field recieves a given type
        /// </summary>
        /// <param name="t">The type to check for</param>
        /// <returns>Whether 't' is a type that is accepted by the macro</returns>
        public bool Is(Type t);
    }
}
