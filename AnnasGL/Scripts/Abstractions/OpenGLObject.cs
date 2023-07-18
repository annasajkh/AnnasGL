namespace AnnasGL.Scripts.Abstractions
{
    // OpenGL Object is an OpenGL construct that contains some state
    public abstract class OpenGLObject : IDisposable
    {
        public int Handle { get; protected set; }

        public abstract void Bind();

        public abstract void Unbind();

        public abstract void Dispose();

        ~OpenGLObject()
        {
            Dispose();
        }
    }
}
