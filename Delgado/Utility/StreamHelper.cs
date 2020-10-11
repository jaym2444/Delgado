using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Delgado.Utility
{
    /// <summary>
    /// Helper class for stuff that has to do with streams
    /// </summary>
    public static class StreamHelper
    {
        /// <summary>
        /// Converts a string to a stream
        /// </summary>
        /// <param name="s">The string </param>
        /// <returns>The stream</returns>
        public static Stream ToStream (this string s)
        {
            var Stream = new MemoryStream();
            var writer = new StreamWriter(Stream);
            writer.Write(s);
            writer.Flush();
            Stream.Position = 0;
            return Stream;
        }
    }
}
