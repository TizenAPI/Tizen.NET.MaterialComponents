using ElmSharp;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using TSystemInfo = Tizen.System.Information;

namespace Tizen.NET.MaterialComponents
{
    public static class MaterialComponents
    {
        static Lazy<TargetProfile> s_profile = new Lazy<TargetProfile>(() =>
        {
            var profile = Elementary.GetProfile();

            if (profile == "mobile")
            {
                return TargetProfile.Mobile;
            }
            else if (profile == "tv")
            {
                return TargetProfile.TV;
            }
            else if (profile == "wearable")
            {
                return TargetProfile.Wearable;
            }
            return TargetProfile.Unsupported;
        });

        public static TargetProfile Profile => s_profile.Value;

        public static bool IsInitialized
        {
            get;
            private set;
        }

        public static string AppResourcePath
        {
            get;
            private set;
        }

        public static InitializationOptions InitOptions
        {
            get;
            private set;
        }

        public static void Init(string resourcePath, InitializationOptions option = null)
        {
            if (!IsInitialized)
            {
                string fileName = "elmsharp-theme-material.edj";
                switch (Profile)
                {
                    case TargetProfile.TV:
                        fileName = "elmsharp-theme-material-tv.edj";
                        break;
                    case TargetProfile.Wearable:
                        fileName = "elmsharp-theme-material-wearable.edj";
                        break;
                    case TargetProfile.Mobile:
                        TSystemInfo.TryGetValue("http://tizen.org/system/device_type", out string deviceType);
                        if (deviceType.Contains("Refrigerator"))
                            fileName = "elmsharp-theme-material-fhub.edj";
                        break;
                }
                Elementary.AddThemeOverlay(Path.Combine(resourcePath, fileName));

                AppResourcePath = resourcePath;
                InitOptions = option;
                IsInitialized = true;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VerifyComponentEnabled(IOptionalComponent component)
        {
            if (InitOptions != null && InitOptions.ThrowOnValidateComponentErrors)
            {
                if (!component.SupportedProfiles.HasFlag(MaterialComponents.Profile))
                {
                    var errorMessage = $"{component} is not supported on {MaterialComponents.Profile} profile. "
                        + $"if you want to check how it works without throwing an exception, please set ComponentsOptions.All when you call MaterialComponents.Init(). ";

                    throw new NotSupportedException(errorMessage);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void VerifyServiceEnabled(TargetProfile supportedProfiles, [CallerMemberName]string caller = "")
        {
            if (InitOptions != null && InitOptions.ThrowOnValidateComponentErrors)
            {
                if (!supportedProfiles.HasFlag(MaterialComponents.Profile))
                {
                    var errorMessage = $"{caller} method is not supported on {MaterialComponents.Profile} profile. "
                        + $"if you want to check how it works without throwing an exception, please set ComponentsOptions.All when you call MaterialComponents.Init(). ";

                    throw new NotSupportedException(errorMessage);
                }
            }
        }
    }
}
