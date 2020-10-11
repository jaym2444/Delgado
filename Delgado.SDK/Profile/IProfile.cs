using System;
using System.Collections.Generic;
using System.Text;

namespace Delgado.SDK.Profile
{
    /// <summary>
    /// A profile to be enabled
    /// </summary>
    public interface IProfile
    {
        /// <summary>
        /// The name of the profile
        /// </summary>
        string Name { get; }

        /// <summary>
        /// The style of the profile (if overridden)
        /// </summary>
        string Style { get; }

        /// <summary>
        /// Whether the profile should use a custom style or not
        /// </summary>
        bool UseCustomStyle { get; }
        /// <summary>
        /// The fields being used and implemented by the profile
        /// </summary>
        IList<IDelgadoField> Fields { get; }
    }
}
