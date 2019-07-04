using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using Tizen.Applications;
using ElmSharp;
using Tizen.NET.MaterialComponents;
using ElmSharp.Wearable;

namespace MaterialGallery
{
    class MaterialWatchGallery : CoreUIApplication
    {
        Window _window;
        int _screenWidth;

        public static string ResourceDir { get; private set; }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            ResourceDir = DirectoryInfo.Resource;
            MaterialGallery.ResourceDir = DirectoryInfo.Resource;
            ThemeLoader.Initialize(ResourceDir);

            _window = new Window("WatchMaterialGallery")
            {
                AvailableRotations = DisplayRotation.Degree_0 | DisplayRotation.Degree_180 | DisplayRotation.Degree_270 | DisplayRotation.Degree_90
            };
            _window.BackButtonPressed += (s, e) =>
            {
                Exit();
            };
            _window.Show();

            _screenWidth = _window.ScreenSize.Width;
            CreateTestPage(_window);
        }

        IEnumerable<BaseGalleryPage> GetGalleryPage()
        {
            Assembly asm = typeof(MaterialWatchGallery).GetTypeInfo().Assembly;
            Type pageType = typeof(BaseGalleryPage);

            var pages = from page in asm.GetTypes()
                        where pageType.IsAssignableFrom(page) && !page.GetTypeInfo().IsInterface && !page.GetTypeInfo().IsAbstract
                        select Activator.CreateInstance(page) as BaseGalleryPage;

            return from page in pages
                   orderby page.Name
                   select page;
        }

        void CreateTestPage(Window window)
        {
            var conformant = new Conformant(window);
            conformant.Show();

            var surface = new CircleSurface(conformant);
            var circleScroller = new CircleScroller(conformant, surface)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                VerticalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Invisible,
                HorizontalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Auto,
                ScrollBlock = ScrollBlock.Vertical,
                HorizontalPageScrollLimit = 1,
            };
            ((IRotaryActionWidget)circleScroller).Activate();
            circleScroller.SetPageSize(1.0, 1.0);
            conformant.SetContent(circleScroller);
            circleScroller.Show();

            var box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsHorizontal = true,
                IsHomogeneous = true,
            };
            box.Show();
            box.PackEnd(CreateFirstPage(box));

            foreach (var tc in GetGalleryPage())
            {
                if(tc.ExceptProfile != ProfileType.Wearable)
                {
                    var view = tc.CreateContent(box);
                    if (view != null)
                    {
                        box.PackEnd(view);
                    }
                    else
                    {
                        box.PackEnd(CreateNewWindow(box, tc));
                    }
                }
            }
            circleScroller.SetContent(box);
        }

        EvasObject CreateNewWindow(EvasObject parent, BaseGalleryPage page)
        {
            var box = new ColoredBox(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var button = new MButton(parent)
            {
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                Text = "click"
            };
            button.Show();

            button.Clicked += (s, e) =>
            {
                Window window = new Window(page.Name);
                window.Show();
                window.BackButtonPressed += (sender, args) =>
                {
                    page.TearDown();
                    window.Hide();
                    window.Unrealize();
                };
                page.Run(window);
            };

            box.PackEnd(button);

            return box;
        }

        EvasObject CreateFirstPage(EvasObject parent)
        {
            var box = new Box(parent)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();

            var label = new Label(parent)
            {
                Text = "<span align='center'>MaterialGallery for Watch<br>▷▷▷</span>",
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                MinimumWidth = _screenWidth,
            };
            label.Show();
            box.PackEnd(label);

            return box;
        }

        static void UIExit()
        {
            EcoreMainloop.Quit();
        }
    }
}
