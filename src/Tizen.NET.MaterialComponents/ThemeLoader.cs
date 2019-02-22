using System;
using System.IO;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public static class ThemeLoader
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

        public static string AppResourcePath
        {
            get;
            private set;
        }

        public static bool IsInitialized
        {
            get;
            private set;
        }

        public static void Initialize(string resourcePath)
        {
            if (!IsInitialized)
            {
                string fileName = "elmsharp-theme-material.edj";
                switch (Profile)
                {
                    case TargetProfile.TV:
                        fileName = "elmsharp-theme-material-tv.edj";
                        Elementary.AddThemeOverlay("elmsharp-theme-material-tv.edj");
                        break;
                    case TargetProfile.Wearable:
                        fileName = "elmsharp-theme-material-wearable.edj";
                        Elementary.AddThemeOverlay("elmsharp-theme-material-wearable.edj");
                        break;
                }
                Elementary.AddThemeOverlay(Path.Combine(resourcePath, fileName));
                AppResourcePath = resourcePath;
                IsInitialized = true;
            }
        }
    }
}
