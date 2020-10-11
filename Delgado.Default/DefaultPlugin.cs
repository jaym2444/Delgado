using Delgado.SDK;
using System;
using System.IO;

namespace Delgado.Default
{
    [Plugin]
    public class DefaultPlugin : IDelgadoPlugin
    {
        public string Name => "Default";

        public Stream Icon => null;
    }
}
