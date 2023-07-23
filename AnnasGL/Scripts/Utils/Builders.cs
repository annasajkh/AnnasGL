using AnnasGL.Scripts.Containers;
using AnnasGL.Scripts.OpenGLObjects;

namespace AnnasGL.Scripts.Utils
{
    public static class Builders
    {
        public static float[] VerticesBuilder(Vertex[] vertices)
        {
            float[] verticesResult = new float[Shader.AllAttributeSize * vertices.Length];

            int index = 0;

            for (int i = 0; i < verticesResult.Length; i += Shader.AllAttributeSize)
            {
                verticesResult[i] = vertices[index].Position.X;
                verticesResult[i + 1] = vertices[index].Position.Y;
                verticesResult[i + 2] = vertices[index].Position.Z;

                verticesResult[i + 3] = vertices[index].Color.R;
                verticesResult[i + 4] = vertices[index].Color.G;
                verticesResult[i + 5] = vertices[index].Color.B;
                verticesResult[i + 6] = vertices[index].Color.A;

                verticesResult[i + 7] = vertices[index].Normal.X;
                verticesResult[i + 8] = vertices[index].Normal.Y;
                verticesResult[i + 9] = vertices[index].Normal.Z;

                verticesResult[i + 10] = vertices[index].TextureCoordinate.X;
                verticesResult[i + 11] = vertices[index].TextureCoordinate.Y;

                index++;
            }


            return verticesResult;

        }

        public static uint[] IndicesBuilder(TriangleIndices[] triangleIndices)
        {
            uint[] trianglesIndicesResult = new uint[3 * triangleIndices.Length];

            int index = 0;

            for (int i = 0; i < trianglesIndicesResult.Length; i += 3)
            {
                trianglesIndicesResult[i] = triangleIndices[index].FirstIndex;
                trianglesIndicesResult[i + 1] = triangleIndices[index].SecondIndex;
                trianglesIndicesResult[i + 2] = triangleIndices[index].ThirdIndex;

                index++;
            }

            return trianglesIndicesResult;
        }
    }
}