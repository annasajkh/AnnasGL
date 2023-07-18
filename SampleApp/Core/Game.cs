using AnnasGL.Scripts.Components;
using AnnasGL.Scripts.OpenGLObjects;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using SampleApp.Core.Entities;
using StbImageSharp;
using System.Drawing;

namespace SampleApp
{
    public class Game : GameWindow
    {
        private Renderer renderer;
        private VertexArrayObject vertexArrayObject;
        private Player player;

        private Mesh cube;
        private Texture2D cubeTexture;
        
        private Vector3 lightPosition;
        
        // 0 - 360
        private float time;

        private int windowWidth, windowHeight;

        public Game(string title, int width, int height)
                : base(GameWindowSettings.Default,
                        new NativeWindowSettings()
                        {
                            Title = title,
                            Size = (width, height)
                        })
        {
            windowWidth = width;
            windowHeight = height;

            // Settings
            CenterWindow();

            GL.Enable(EnableCap.DepthTest);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            StbImage.stbi_set_flip_vertically_on_load(1);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.ClampToEdge);

            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMinFilter.Linear);

            // Setup the Renderer

            renderer = new Renderer(new Shader(vertexShaderPath: Path.GetFullPath("shaders/default.vert"),
                                               geometryShaderPath: Path.GetFullPath("shaders/default.geom"),
                                               fragmentShaderPath: Path.GetFullPath("shaders/default.frag")));

            renderer.Shader.Bind();
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.ambient"), 1.25f, 1.25f, 1.25f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.diffuse"), 1f, 1f, 1f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.specular"), 1f, 1f, 1f);
            GL.Uniform1(renderer.Shader.GetUniformLocation("material.shininess"), 32f);

            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.ambient"), 1.25f, 1.25f, 1.25f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.diffuse"), 1f, 1f, 1f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.specular"), 1f, 1f, 1f);
            renderer.Shader.Unbind();

            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);


            // Initialization
            player = new Player(position: Vector3.Zero,
                                rotation: Vector3.Zero,
                                scale: Vector3.One,
                                cameraSize: new Vector2(width, height));


            cubeTexture = new Texture2D(ImageResult.FromStream(File.OpenRead("textures/annasvirtual.png"), ColorComponents.RedGreenBlueAlpha));
            cube = new Mesh(Vector3.Zero, Vector3.Zero, new Vector3(50, 50, 50), BufferUsageHint.StaticDraw, MeshInstance.Cube);
            
            lightPosition = new Vector3(0, 100, 0);

            vertexArrayObject = new VertexArrayObject();
        }

        protected override void OnLoad()
        {
            base.OnLoad();
        }

        protected override void OnResize(ResizeEventArgs resizeEventArgs)
        {
            base.OnResize(resizeEventArgs);

            windowWidth = resizeEventArgs.Width;
            windowHeight = resizeEventArgs.Height;

            GL.Viewport(0, 0, resizeEventArgs.Width, resizeEventArgs.Height);

            player.Camera.Resize(resizeEventArgs.Width, resizeEventArgs.Height);
            renderer.Projection = player.Camera.ProjectionMatrix;
        }

        protected override void OnUnload()
        {
            base.OnUnload();

            renderer.Dispose();
            cube.Dispose();
            cubeTexture.Dispose();
        }

        protected override void OnUpdateFrame(FrameEventArgs frameEventArgs)
        {
            base.OnUpdateFrame(frameEventArgs);

            KeyboardState keyboardState = KeyboardState;

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            player.Update(KeyboardState, MouseState, (float)frameEventArgs.Time);

            renderer.View = player.Camera.ViewMatrix;

            Vector3 sunDirection = Vector3.Normalize(lightPosition - player.Position);

            renderer.Shader.Bind();


            GL.Uniform3(renderer.Shader.GetUniformLocation("lightColor"), 1f, 1f, 1f);

            GL.Uniform3(renderer.Shader.GetUniformLocation("uViewPos"), player.Position);
            GL.Uniform3(renderer.Shader.GetUniformLocation("uLightPos"), lightPosition);
            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.direction"), sunDirection);

            renderer.Shader.Unbind();

            lightPosition = player.Position + new Vector3((float)MathHelper.Cos(MathHelper.DegreesToRadians(time)), (float)MathHelper.Sin(MathHelper.DegreesToRadians(time)), 0) * 5000;


            cube.Rotation = new Vector3(x: cube.Rotation.X + (float)frameEventArgs.Time * 50, 
                                        y: 0, 
                                        z: cube.Rotation.Z + (float)frameEventArgs.Time * 50);

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                time += (float)frameEventArgs.Time;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                time -= (float)frameEventArgs.Time;
            }

            if (keyboardState.IsKeyDown(Keys.P))
            {
                CursorState = CursorState.Normal;
            }
            else
            {
                CursorState = CursorState.Grabbed;
            }

            if (time > 360)
            {
                time = 0;
            }
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            GL.ClearColor(Color.CornflowerBlue);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            renderer.Begin();

            GL.Enable(EnableCap.Blend);
            GL.Disable(EnableCap.CullFace);

            renderer.Draw(cube, cubeTexture, vertexArrayObject);

            renderer.End();

            SwapBuffers();
        }
    }
}