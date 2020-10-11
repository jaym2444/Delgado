using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.SDK.Macro
{
    /// <summary>
    /// A field to be used displayed and let the user configure
    /// </summary>
    public class MacroConfigurationField<T>
    {
        /// <summary>
        /// The name of the macro
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Creates a new macro configuration field
        /// </summary>
        /// <param name="name">The name of the field</param>
        public MacroConfigurationField(string name)
        {
            Name = name;
        }
        /// <summary>
        /// The value of the macro
        /// </summary>
        public T Value { get; }
        /// <summary>
        /// Evaluates whether this configuration field recieves a given type
        /// </summary>
        /// <param name="t">The type to check for</param>
        /// <returns>Whether 't' is a type that is accepted by the macro</returns>
        public bool Is(Type t)
        {
            if (typeof(T) == t)
                return true;
            return false;
        }
    }
}
