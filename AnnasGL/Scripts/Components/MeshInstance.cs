using AnnasGL.Scripts.Containers;
using OpenTK.Mathematics;

namespace AnnasGL.Scripts.Components
{
    public class MeshInstance
    {
        public static MeshInstance Quad { get; } = new MeshInstance(

        new Vertex[]
        {
            new Vertex(new Vector3(-1, 0, -1), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(0, 0)),
            new Vertex(new Vector3(-1, 0, 1), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1, 0)),
            new Vertex(new Vector3(1, 0, 1), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1, 1)),
            new Vertex(new Vector3(1, 0, -1), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(0, 1))
        },

        new TriangleIndices[]
        {
            new TriangleIndices(0, 1, 3),
            new TriangleIndices(1, 2, 3)
        });

        public static MeshInstance Cube { get; } = new MeshInstance(

        new Vertex[]
        {
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 1.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(0.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 0.0f)),
            new Vertex(new Vector3(0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2(1.0f, 1.0f)),
            new Vertex(new Vector3(-0.5f, -0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f, -0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 1.0f, 0.0f)),
            new Vertex(new Vector3(-0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 1.0f, 1.0f)),
            new Vertex(new Vector3(0.5f,  0.5f,  0.5f), new Color4(1f, 1f, 1f, 1f), Vector3.Zero, new Vector2( 0.0f, 1.0f))
        },

        new TriangleIndices[]
        {
            new TriangleIndices(0, 3, 2),
            new TriangleIndices(2, 1, 0),
            new TriangleIndices(4, 5, 6),
            new TriangleIndices(6, 7 ,4),
            new TriangleIndices(11, 8, 9),
            new TriangleIndices(9, 10, 11),
            new TriangleIndices(12, 13, 14),
            new TriangleIndices(14, 15, 12),
            new TriangleIndices(16, 17, 18),
            new TriangleIndices(18, 19, 16),
            new TriangleIndices(20, 21, 22),
            new TriangleIndices(22, 23, 20)
        });


        public Vertex[] Vertices { get; }
        public TriangleIndices[] TriangleIndices { get; }

        public MeshInstance(Vertex[] vertices, TriangleIndices[] triangleIndices)
        {
            Vertices = vertices;
            TriangleIndices = triangleIndices;
        }
    }
}