using AnnasGL.Scripts.OpenGLObjects;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace AnnasGL.Scripts.Components
{
    public class Renderer : IDisposable
    {
        private Matrix4 model;
        private Matrix4 view;
        private Matrix4 projection;

        public Shader Shader { get; set; }

        public Matrix4 Model
        {
            get
            {
                return model;
            }
        }

        public Matrix4 View
        {
            get
            {
                return view;
            }

            set
            {
                view = value;
            }
        }

        public Matrix4 Projection
        {
            get
            {
                return projection;
            }

            set
            {
                projection = value;
            }
        }

        public Renderer(Shader shader)
        {
            Shader = shader;

            model = Matrix4.Identity;
            View = Matrix4.Identity;
            Projection = Matrix4.Identity;
        }

        public void Begin()
        {
            Shader.Bind();

            GL.UniformMatrix4(Shader.GetUniformLocation("uView"), false, ref view);
            GL.UniformMatrix4(Shader.GetUniformLocation("uProjection"), false, ref projection);
        }

        public void Draw(Mesh mesh, Texture2D texture, VertexArrayObject vertexArrayObject)
        {
            vertexArrayObject.Bind();

            texture.Bind();

            model = mesh.ModelMatrix;

            GL.UniformMatrix4(Shader.GetUniformLocation("uModel"), false, ref model);

            mesh.Bind();

            vertexArrayObject.ApplyAttributes();

            GL.DrawElements(PrimitiveType.Triangles, mesh.TriangleIndices.Length * 3, DrawElementsType.UnsignedInt, 0);

            mesh.Unbind();
        }

        public void End()
        {
            Shader.Unbind();
        }

        public void Dispose()
        {
            Shader.Dispose();
            GC.SuppressFinalize(this);
        }

        ~Renderer()
        {
            Dispose();
        }
    }
}