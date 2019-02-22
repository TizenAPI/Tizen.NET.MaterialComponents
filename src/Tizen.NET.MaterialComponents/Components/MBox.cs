using System;
using ElmSharp;

namespace Tizen.NET.MaterialComponents
{
    public class MBox : Box
    {
        Rect _previousGeometry;

        public MBox(EvasObject parent) : base(parent)
        {
            SetLayoutCallback(() => { NotifyOnLayout(); });
        }

        public event EventHandler<MLayoutEventArgs> LayoutUpdated;

        void NotifyOnLayout()
        {
            if (null != LayoutUpdated)
            {
                var g = Geometry;

                if (0 == g.Width || 0 == g.Height || g == _previousGeometry)
                {
                    // ignore irrelevant dimensions
                    return;
                }

                LayoutUpdated(this, new MLayoutEventArgs()
                {
                    Geometry = g,
                });

                _previousGeometry = g;
            }
        }
    }

    public class MLayoutEventArgs : EventArgs
    {
        public Rect Geometry
        {
            get;
            internal set;
        }
    }
}
