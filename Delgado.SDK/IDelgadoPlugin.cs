using System;
using System.IO;

namespace Delgado.SDK
{
    /// <summary>
    /// A delgado plugin manifest. Needed in order for the plugin to be recognized and loaded.
    /// </summary>
    public interface IDelgadoPlugin
    {
        /// <summary>
        /// The name of the plugin
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The icon of the plugin
        /// </summary>
        Stream Icon { get; }
    }
}
