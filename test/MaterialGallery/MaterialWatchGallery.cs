using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Tizen.Applications;
using Tizen.NET.MaterialComponents;
using ElmSharp;

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
            MaterialComponents.Init(ResourceDir, new InitializationOptions
            {
                ThrowOnValidateComponentErrors = false
            });

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

            var circleScroller = new Scroller(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                VerticalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Invisible,
                HorizontalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Visible,
                ScrollBlock = ScrollBlock.Vertical,
                HorizontalPageScrollLimit = 1,
            };
            circleScroller.SetPageSize(1.0, 1.0);
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

            var pages = GetGalleryPage();
            foreach (var tc in pages)
            {
                if (tc.RunningOnNewWindow)
                {
                    var view = CreateNewWindow(box, tc);
                    view.Show();
                    box.PackEnd(view);
                }
                else
                {
                    var view = tc.CreateContent(box);
                    if (view != null)
                    {
                        view.Show();
                        box.PackEnd(view);
                    }
                }
            }

            circleScroller.SetContent(box);
            conformant.SetContent(circleScroller);
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

            var titleLabel = new Label(parent)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 1,
                LineWrapType = WrapType.Word,
                LineWrapWidth = 300,
                Text = $"<span align=center color=#000000>{page.Name}</span > "
            };
            titleLabel.Show();

            var button = new MButton(parent)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 1,
                Text = "run"
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

            box.PackEnd(titleLabel);
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
                Text = "<span align='center'>MaterialGallery<br>for Watch <br>▷▷▷</span>",
                AlignmentX = 0.5,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                LineWrapType = WrapType.Word,
                LineWrapWidth = _screenWidth,
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
