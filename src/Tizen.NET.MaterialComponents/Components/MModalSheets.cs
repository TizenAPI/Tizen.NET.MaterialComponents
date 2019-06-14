using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MModalSheets : Panel
    {
        Box _scrim;
        double _bottomSheetDefaultRatio = 0.5;
        double _bottomSheetMinimumRatio = 0.085;
        double _ratio;
        double _sideSheetDefaultRatio = 0.85;
        double _sideSheetMinimumRatio = 0.5;

        public MModalSheets(MConformant conformant, MModalSheetsDirection direction) : base(conformant)
        {
            _scrim = new Box(conformant)
            {
                BackgroundColor = Color.Transparent,
                RepeatEvents = true,
            };

            Style = Styles.Material;
            SetScrollable(true);
            UpdateDirection(direction);
            AlignmentX = -1;
            AlignmentY = -1;
            WeightX = 1;
            WeightY = 1;
            Toggled += (s, e) => { UpdateScrim(); };
            IsOpen = false;
            BackgroundColor = Color.White;

            _scrim.PackEnd(this);
            conformant.SetPartContent(Parts.Layout.Sheets, _scrim);
        }

        void UpdateDirection(MModalSheetsDirection direction)
        {
            if (direction == MModalSheetsDirection.Bottom)
            {
                Direction = PanelDirection.Bottom;
                UpdateRatio(_bottomSheetDefaultRatio);
            }
            else
            {
                Direction = PanelDirection.Right;
                UpdateRatio(_sideSheetDefaultRatio);
            }
        }

        void UpdateRatio(double ratio)
        {
            if (Direction == PanelDirection.Bottom)
            {
                if (ratio < _bottomSheetMinimumRatio)
                {
                    _ratio = _bottomSheetMinimumRatio;
                }
                else if (ratio > _bottomSheetDefaultRatio)
                {
                    _ratio = _bottomSheetDefaultRatio;
                }
                else
                {
                    _ratio = ratio;
                }
            }
            else
            {
                if (ratio < _sideSheetMinimumRatio)
                {
                    _ratio = _sideSheetMinimumRatio;
                }
                else if (ratio > _sideSheetDefaultRatio)
                {
                    _ratio = _sideSheetDefaultRatio;
                }
                else
                {
                    _ratio = ratio;
                }
            }
            SetScrollableArea(_ratio);
        }

        void UpdateScrim()
        {
            if (IsOpen)
            {
                _scrim.BackgroundColor = MColors.Current.OnSurfaceColor.WithAlpha(0.32);
                _scrim.RepeatEvents = false;
            }
            else
            {
                _scrim.BackgroundColor = Color.Transparent;
                _scrim.RepeatEvents = true;
            }
        }
    }

    public enum MModalSheetsDirection
    {
        Bottom,
        Side,
    }
}
