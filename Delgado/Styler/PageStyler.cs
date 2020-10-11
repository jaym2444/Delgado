using System;
using System.Collections.Generic;

namespace Delgado.Styler
{
    public class PageStyler : IStyler
    {
        List<string> CSSEntries = new List<string>();
        public PageStyler(SDK.Profile.IProfile profile, SDK.Macro.IMacro[] macros)
        {
            if (profile.UseCustomStyle)
            {
                CSSEntries.Add(profile.Style);
            }
            Array.ForEach(macros, (macro) =>
            {
                if (macro.IsStyled())
                {
                    CSSEntries.Add(".fixhere {" + macro.ToStyled().Style + "}");
                }
            });
        }

        public string Style()
        {
            throw new NotImplementedException();
        }
    }
}
