using AnnasGL.Scripts.Abstractions;
using AnnasGL.Scripts.Interfaces;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace SampleApp.Core.Entities
{
    public abstract class Entity : GameObject, IUpdateable
    {
        public Vector3 Velocity { get; set; }

        public Entity(Vector3 position, Vector3 rotation, Vector3 scale) : base(position, rotation, scale)
        {
            Velocity = new Vector3();
        }

        public virtual void Update(KeyboardState keyboardState, MouseState mouseState, float delta)
        {
            Position += Velocity * delta;
        }
    }
}