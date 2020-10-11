using Avalonia.Media.Imaging;
using Delgado.SDK;
using Delgado.SDK.Macro;
using Delgado.SDK.Profile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Delgado.Runtime
{
    /// <summary>
    /// A plugin to be loaded
    /// </summary>
    public class Plugin
    {
        /// <summary>
        /// The name of the plugin
        /// </summary>
        public string Name { get => _name; }
        /// <summary>
        /// The icon of the plugin
        /// </summary>
        public IBitmap Icon { get => _icon; }

        /// <summary>
        /// The macros defined by the plugin
        /// </summary>
        public ConstructableMacro[] Macros { get => _macros.ToArray(); }

        /// <summary>
        /// The profiles defined by the plugin
        /// </summary>
        public IProfile[] Profiles { get => _profiles.ToArray(); }

        private Assembly _assembly;
        private IDelgadoPlugin _plugin;
        private bool _isValidPlugin = false;
        private string _name;
        private IBitmap _icon;
        private List<ConstructableMacro> _macros = new List<ConstructableMacro>();
        private List<IProfile> _profiles = new List<IProfile>();
        /// <summary>
        /// Loads a specific plugin assembly
        /// </summary>
        /// <param name="assembly">The location of the assembly</param>
        public Plugin(string assembly)
        {
            if (!File.Exists(assembly))
                throw new FileNotFoundException("The given assembly does not exist. " + assembly);
            try
            {
                _assembly = Assembly.LoadFrom(assembly);
            }
            catch
            {
                throw new InvalidFileException("The file is not a valid MSIL assembly. " + assembly);
            }
            foreach (var type in _assembly.GetTypes())
            {
                // Has a plugin attribute
                var plAttribute = type.GetCustomAttribute<PluginAttribute>();
                if (plAttribute != null)
                {
                    processPlugin(type);
                    continue;
                }
                // Has a macro attribute
                var macroAttribute = type.GetCustomAttribute<MacroAttribute>();
                if (macroAttribute != null)
                {
                    processMacro(type);
                    continue;
                }
                // Has a profile attribute
                var profileAttribute = type.GetCustomAttribute<ProfileAttribute>();
                if (profileAttribute != null)
                {
                    processProfile(type);
                    continue;
                }
            }
            if (_plugin == null)
                throw new InvalidFileException("While the file is a valid MSIL assembly, it does not contain a plugin manifest.");

        }

        /// <summary>
        /// Gets if a given assembly is a valid Delgado plguin
        /// </summary>
        /// <param name="assembly">The assembly to evaluate</param>
        /// <returns>If the assembly is a Delgado plugin</returns>
        public static bool IsPlugin(string assembly)
        {
            return false;
        }
        /// <summary>
        /// Processes a type believed to hold the plugin manifest data
        /// </summary>
        /// <param name="t">The plugin manifest type</param>
        private void processPlugin(Type t)
        {
            object instance;
            try
            {
                instance = Activator.CreateInstance(t);
            }catch (Exception ex)
            {
                throw new InvalidPluginManifestException($"The plugin {_assembly.FullName} has defined a plugin manifest {t.Name} but it could not be initiated.", ex);
            }
            
            if (instance is IDelgadoPlugin)
            {
                _plugin = (IDelgadoPlugin)instance;
            }
            else
            {
                throw new InvalidPluginManifestException($"The plugin {_assembly.FullName} has defined a plugin manifest {t.Name} but that plugin manifest does not implement the IDelgadoPlugin interface.");
            }
            if (string.IsNullOrWhiteSpace(_plugin.Name))
            {
                throw new InvalidPluginManifestException($"The plugin {_assembly.FullName}.{t.Name} has defined a name that is empty, null, or whitespace.");
            }
            _name = _plugin.Name;
            if (_plugin.Icon == null)
            {
                throw new InvalidPluginManifestException($"The plugin {_assembly.FullName}.{t.Name} has defined an Icon that is null.");
            }
            if (!_plugin.Icon.CanRead)
            {
                throw new InvalidPluginManifestException($"The plugin {_assembly.FullName}.{t.Name} has defined an Icon that cannot be read from, possibly due to the stream being closed.");
            }
            _icon = new Bitmap(_plugin.Icon);

        }
        /// <summary>
        /// Processes a type believed to be a macro
        /// </summary>
        /// <param name="t">The type of the macro</param>
        private void processMacro(Type t)
        {
            object instance;
            try
            {
                instance = Activator.CreateInstance(t);
            }
            catch (Exception ex)
            {
                throw new InvalidMacroException($"The plugin {_assembly.FullName} defines a macro {t.Name} but it cannot be constructed.", ex);
            }
            
            if (instance is IMacro)
            {
                _macros.Add(new ConstructableMacro(t, this));
            }
            else
            {
                throw new InvalidMacroException($"The plugin {_assembly.FullName} defines a macro {t.Name} that does not implement the IMacro interface.");
            }
        }

        /// <summary>
        /// Processes a type believed to be a profile
        /// </summary>
        /// <param name="t">The type of the profile</param>
        private void processProfile(Type t)
        {
            object instance;
            try
            {
                instance = Activator.CreateInstance(t);
            }
            catch (Exception ex)
            {
                throw new InvalidProfileException($"The plugin {_assembly.FullName} defines a profile {t.Name} but it cannot be constructed.", ex);
            }

            if (instance is IProfile)
            {
                _profiles.Add((IProfile)instance);
            }
            else
            {
                throw new InvalidMacroException($"The plugin {_assembly.FullName} defines a profile {t.Name} that does not implement the IProfile interface.");
            }
        }
        
    }
}
