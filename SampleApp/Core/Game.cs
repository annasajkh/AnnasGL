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
        private Mesh sun;

        private Texture2D cubeTexture;
        private Texture2D sunTexture;

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
            
            //GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
        }

        protected override void OnLoad()
        {
            base.OnLoad();

            // Setup the Renderer

            renderer = new Renderer(new Shader(vertexShaderPath: Path.GetFullPath("resources/shaders/default.vert"),
                                               geometryShaderPath: Path.GetFullPath("resources/shaders/default.geom"),
                                               fragmentShaderPath: Path.GetFullPath("resources/shaders/default.frag")));

            renderer.Shader.Bind();
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.ambient"), 1.25f, 1.25f, 1.25f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.diffuse"), 0.5f, 0.5f, 0.5f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("material.specular"), 1f, 1f, 1f);
            GL.Uniform1(renderer.Shader.GetUniformLocation("material.shininess"), 32f);

            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.ambient"), 1.25f, 1.25f, 1.25f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.diffuse"), 0.5f, 0.5f, 0.5f);
            GL.Uniform3(renderer.Shader.GetUniformLocation("dirLight.specular"), 1f, 1f, 1f);
            renderer.Shader.Unbind();

            // Initialization
            player = new Player(position: Vector3.Zero,
                                rotation: Vector3.Zero,
                                scale: Vector3.One,
                                cameraSize: new Vector2(windowWidth, windowHeight));


            cubeTexture = new Texture2D(ImageResult.FromStream(File.OpenRead("resources/textures/annasvirtual.png"), ColorComponents.RedGreenBlueAlpha));
            sunTexture = new Texture2D(ImageResult.FromStream(File.OpenRead("resources/textures/sun.png"), ColorComponents.RedGreenBlueAlpha));

            cube = new Mesh(Vector3.Zero, Vector3.Zero, new Vector3(50, 50, 50), BufferUsageHint.StaticDraw, MeshInstance.Cube);
            sun = new Mesh(Vector3.Zero, Vector3.Zero, new Vector3(500, 1, 500), BufferUsageHint.StaticDraw, MeshInstance.Quad);

            lightPosition = new Vector3(0, 100, 0);

            vertexArrayObject = new VertexArrayObject();
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

            sun.Dispose();
            sunTexture.Dispose();
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

            sun.Position = lightPosition + new Vector3((float)MathHelper.Cos(MathHelper.DegreesToRadians(time)), (float)MathHelper.Sin(MathHelper.DegreesToRadians(time)), 0) * 100;
            sun.Rotation = new Vector3(0, 90, -MathHelper.RadiansToDegrees((float)MathHelper.Atan2(MathHelper.Cos(MathHelper.DegreesToRadians(time)), MathHelper.Sin(MathHelper.DegreesToRadians(time)))));

            cube.Rotation = new Vector3(x: cube.Rotation.X + (float)frameEventArgs.Time * 50, 
                                        y: 0, 
                                        z: cube.Rotation.Z + (float)frameEventArgs.Time * 50);

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                time += (float)frameEventArgs.Time * 100;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                time -= (float)frameEventArgs.Time * 100;
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

            renderer.Draw(sun, sunTexture, vertexArrayObject);

            GL.Clear(ClearBufferMask.DepthBufferBit);

            GL.Enable(EnableCap.Blend);
            GL.Disable(EnableCap.CullFace);

            renderer.Draw(cube, cubeTexture, vertexArrayObject);

            renderer.End();

            SwapBuffers();
        }
    }
}