﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Chocolatey" file="VersionNumberProvider.cs">
//   Copyright 2014 - Present Rob Reynolds, the maintainers of Chocolatey, and RealDimensions Software, LLC
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Linq;
using System.Reflection;
using ChocolateyGui.Properties;

namespace ChocolateyGui.Providers
{
    public class VersionNumberProvider : IVersionNumberProvider
    {
        private string _version;

        public virtual string Version
        {
            get
            {
                if (_version != null)
                {
                    return _version;
                }

                var assembly = GetType().Assembly;
                var informational =
                    ((AssemblyInformationalVersionAttribute[])assembly.GetCustomAttributes(typeof(AssemblyInformationalVersionAttribute)))
                        .First();

                _version = string.Format(Resources.VersionNumberProvider_VersionFormat, informational.InformationalVersion);
                return _version;
            }
        }
    }
}