using System;
namespace Delgado.SDK.Macro
{
    public interface IStyledMacro : IMacro
    {
        /// <summary>
        /// The CSS style that will be used by the HTML element in the page crafter
        /// </summary>
        public string Style { get; }

        /// <summary>
        /// The raw HTML of the macro element
        /// </summary>
        public string Html { get; }
    }
}
