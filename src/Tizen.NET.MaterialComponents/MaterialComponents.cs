using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Tizen.NET.MaterialComponents
{
    public enum ComponentsOptions
    {
        All,
        Supported
    }

    public static class MaterialComponents
    {

        public static bool IsInitialized
        {
            get;
            private set;
        }

        public static ComponentsOptions ComponentOption
        {
            get;
            private set;
        }

        public static void Init(string resourcePath, ComponentsOptions option = ComponentsOptions.All)
        {
            if (!IsInitialized)
            {
                ThemeLoader.Initialize(resourcePath);
                ComponentOption = option;
                IsInitialized = true;
            }           
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VerifyComponentEnabled(IOptionalComponent component)
        {
            if (ComponentOption == ComponentsOptions.Supported)
            {
                if (!component.SupportedProfiles.HasFlag(ThemeLoader.Profile))
                {
                    var errorMessage = $"{component} is not supported on {ThemeLoader.Profile} profile. "
                        + $"if you want to check how it works without throwing an exception, please set ComponentsOptions.All when you call MaterialComponents.Init(). ";

                    throw new NotSupportedException(errorMessage);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VerifyServiceEnabled(TargetProfile supportedProfiles, [CallerMemberName]string caller = "")
        {
            if (ComponentOption == ComponentsOptions.Supported)
            {
                if (!supportedProfiles.HasFlag(ThemeLoader.Profile))
                {
                    var errorMessage = $"{caller} method is not supported on {ThemeLoader.Profile} profile. "
                        + $"if you want to check how it works without throwing an exception, please set ComponentsOptions.All when you call MaterialComponents.Init(). ";

                    throw new NotSupportedException(errorMessage);
                }
            }
        }
    }
}
