using OpenTK.Mathematics;

namespace AnnasGL.Scripts.Abstractions
{
    // GameObject3D representing position, rotation, and scale of an object in 3D space
    public abstract class GameObject3D
    {
        public Vector3 Position { get; set; }

        public Vector3 Rotation { get; set; }

        public Vector3 Scale { get; set; }

        public GameObject3D(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            Position = position;
            Rotation = rotation;
            Scale = scale;
        }
    }
}