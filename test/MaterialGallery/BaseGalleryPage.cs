using ElmSharp;

namespace MaterialGallery
{
    public abstract class BaseGalleryPage
    {
        public abstract string Name { get; }
        public abstract void Run(Window window);
        public virtual void TearDown() { }
    }
}
