using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Tizen.Applications;
using ElmSharp;
using Tizen.NET.MaterialComponents;

namespace MaterialGallery
{
    class MaterialGallery : CoreUIApplication
    {
        Window _mainWindow;

        public static string ResourceDir { get; internal set; }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            ResourceDir = DirectoryInfo.Resource;
            MaterialComponents.Init(ResourceDir, new InitializationOptions
            {
                ThrowOnValidateComponentErrors = false
            });

            _mainWindow = new Window("MaterialGallery");
            _mainWindow.Show();
            _mainWindow.BackButtonPressed += (s, e) =>
            {
                UIExit();
            };

            var conformant = new Conformant(_mainWindow);
            conformant.Show();

            var box = new Box(_mainWindow)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var bg = new Background(_mainWindow)
            {
                Color = Color.White
            };
            bg.SetContent(box);
            conformant.SetContent(bg);

            GenList list = new GenList(_mainWindow)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (data, part) =>
                {
                    BaseGalleryPage page = data as BaseGalleryPage;
                    return page == null ? "" : page.Name;
                }
            };

            foreach (var page in GetGalleryPage())
            {
                list.Append(defaultClass, page);
            }

            if (MaterialComponents.Profile == TargetProfile.Wearable)
            {
                list.Prepend(defaultClass, null);
                list.Append(defaultClass, null);
            }

            list.ItemSelected += (s, e) =>
            {
                BaseGalleryPage page = e.Item.Data as BaseGalleryPage;
                RunGalleryPage(page);
            };
            list.Show();
            box.PackEnd(list);
        }

        void RunGalleryPage(BaseGalleryPage page)
        {
            Window window = CreatePageWindow(page);
            page.Run(window);
        }        

        IEnumerable<BaseGalleryPage> GetGalleryPage()
        {
            Assembly asm = typeof(MaterialGallery).GetTypeInfo().Assembly;
            Type pageType = typeof(BaseGalleryPage);

            var pages = from page in asm.GetTypes()
                        where pageType.IsAssignableFrom(page) && !page.GetTypeInfo().IsInterface && !page.GetTypeInfo().IsAbstract
                        select Activator.CreateInstance(page) as BaseGalleryPage;

            return from page in pages
                   orderby page.Name
                   select page;
        }

        Window CreatePageWindow(BaseGalleryPage page)
        {
            Window window = new Window("MaterialGalleryPageWindow");
            window.Show();
            window.BackButtonPressed += (s, e) =>
            {
                page.TearDown();
                window.Hide();
                window.Unrealize();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            };
            return window;
        }

        static void UIExit()
        {
            EcoreMainloop.Quit();
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();

            CoreUIApplication app;

            if (Elementary.GetProfile() == "wearable")
            {
                app = new MaterialWatchGallery();
            }
            else
            {
                app = new MaterialGallery();
            }

            app.Run(args);
        }
    }
}
