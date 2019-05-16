using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public static class Styles
    {
        public static readonly string Material = "material";

        public static readonly string MaterialApplication = "material_application";

        public class CheckBox
        {
            public static readonly string Style = "material_checkboxes";
        }

        public class Entry
        {
            public static readonly string Singleline = "singleline";
        }

        public class ProgressBar
        {
            public static readonly string MaterialCircular = "material_circular";
        }

        public class RadioButton
        {
            public static readonly string Style = "material_radio_buttons";
        }

        public class Switch
        {
            public static readonly string Style = "material_switches";
        }

        public class GenListItem
        {
            public static readonly string MaterialNavigation = "material_navigation";
            public static readonly string MaterialNavigationSubtitle = "material_navigation_subtitle";
            public static readonly string MaterialNavigationDivider = "material_navigation_divider";
        }

        public class Popup
        {
            public static readonly string SnackBars = "material_snackbars";
            public static readonly string ActionButton = "material_popup";
        }

        public class Button
        {
            public static readonly string FloatingButton = "floatingbutton/material";
        }
    }

    public static class Parts
    {
        public class Widget
        {
            public static readonly string Background = "bg";
            public static readonly string BackgroundPressed = "bg_pressed";
            public static readonly string BackgroundDisabled = "bg_disabled";

            public static readonly string Text = "text";
            public static readonly string TextPressed = "text_pressed";
            public static readonly string TextDisabled = "text_disabled";

            public static readonly string Icon = "icon";
            public static readonly string IconPressed = "icon_pressed";
        }

        public class Layout
        {
            public static readonly string Content = "elm.swallow.content";
            public static readonly string Border = "border";
            public static readonly string FloatingButton = "elm.swallow.floatingbutton";
        }

        public class Check
        {
            public static readonly string Background = "bg_on";
            public static readonly string BackgroundDisabled = "bg_on_disabled";
        }

        public class Entry
        {
            public static readonly string Label = "label";
            public static readonly string Cursor = "cursor";
            public static readonly string Guide = "elm.guide";
            public static readonly string TextLabel = "elm.text.label";
            public static readonly string TextEdit = "text_edit";
            public static readonly string TextEditFocused = "text_edit_focused";
            public static readonly string Underline = "underline";
            public static readonly string UnderlineFocused = "underline_focused";
        }

        public class GenListItem
        {
            public static readonly string BackgroundActivated = "active_bg";
        }

        public class ProgressBar
        {
            public static readonly string Bar = "bar";
            public static readonly string BarDisabled = "bar_disabled";
        }

        public class Radio
        {
            public static readonly string Icon = "icon";
            public static readonly string IconDisabled = "icon_disabled";
        }

        public class Slider
        {
            public static readonly string Bar = "bar";
            public static readonly string BarPressed = "bar_pressed";
            public static readonly string BarDisabled = "bar_disabled";

            public static readonly string Handler = "handler";
            public static readonly string Handler2 = "handler2";
            public static readonly string HandlerPressed = "handler_pressed";
            public static readonly string HandlerDisabled = "handler_disabled";
        }

        public class Switch
        {
            public static readonly string SliderOn = "slider_on";
            public static readonly string SliderDisabledOn = "slider_disabled_on";
            public static readonly string ShapeOn = "shape_on";
            public static readonly string ShapeDisabledOn = "shape_disabled_on";
        }

        public class ToolbarItem
        {
            public static readonly string Background = "bg";
            public static readonly string Text = "text";
            public static readonly string TextSelected = "text_selected";
            public static readonly string Underline = "underline";
        }

        public class Popup
        {
            public static readonly string ActionButton = "button1";
        }

        public class Menus
        {
            public static readonly string Divider = "divider";
        }
    }

    public static class Actions
    {
        public static readonly string ShowShadow = "elm,action,show,shadow";
        public static readonly string HideShadow = "elm,action,hide,shadow";
    }

    public static class States
    {
        public static readonly string Activate = "elm,state,activate";
        public static readonly string Unactivate = "elm,state,unactivate";
        public static readonly string Focused = "elm,state,focused";
        public static readonly string Unfocused = "elm,state,unfocused";
    }

    public static class Events
    {
        public static readonly string Changed = "changed";
    }
}
