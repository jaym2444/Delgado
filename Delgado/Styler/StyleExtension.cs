using System;
using Delgado.SDK.Macro;

namespace Delgado.Styler
{
    public static class StyleExtension
    {
        public static bool IsStyled(this IMacro macro)
        {
            if (macro is IStyledMacro)
            {
                return true;
            }
            return false;
        }
        public static IStyledMacro ToStyled(this IMacro macro)
        {
            if (macro.IsStyled())
                return (IStyledMacro)macro;
            return null;
        }
    }
}
