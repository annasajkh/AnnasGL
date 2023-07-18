using OpenTK.Windowing.GraphicsLibraryFramework;

namespace AnnasGL.Scripts.Interfaces
{
    public interface IUpdateable
    {
        public void Update(KeyboardState keyboardState, MouseState mouseState, float delta);
    }
}