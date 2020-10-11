using Delgado.SDK.Macro;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Delgado.SDK.Profile
{
    /// <summary>
    /// Holds data about buttons and executors in Delgado
    /// </summary>
    public interface IDelgadoField
    {
        /// <summary>
        /// The name of the field
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The stream of the icon
        /// </summary>
        Stream Icon { get; set; }
        /// <summary>
        /// The macro to be executed by the button and field
        /// </summary>
        IMacro Macro { get; }
    }
}
