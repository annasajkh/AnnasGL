namespace AnnasGL.Scripts.Containers
{
    public struct TriangleIndices
    {
        public uint FirstIndex { get; set; }
        public uint SecondIndex { get; set; }
        public uint ThirdIndex { get; set; }

        public TriangleIndices(uint firstIndex, uint secondIndex, uint thirdIndex)
        {
            FirstIndex = firstIndex;
            SecondIndex = secondIndex;
            ThirdIndex = thirdIndex;
        }

        public override string ToString()
        {
            return $"Indices: [{FirstIndex}, {SecondIndex}, {ThirdIndex}]";
        }

        public static TriangleIndices operator +(TriangleIndices indicesA, TriangleIndices indicesB)
        {
            return new TriangleIndices(indicesA.FirstIndex + indicesB.FirstIndex,
                               indicesA.SecondIndex + indicesB.SecondIndex,
                               indicesA.ThirdIndex + indicesB.ThirdIndex);
        }

        public static TriangleIndices operator -(TriangleIndices indicesA, TriangleIndices indicesB)
        {
            return new TriangleIndices(indicesA.FirstIndex - indicesB.FirstIndex,
                               indicesA.SecondIndex - indicesB.SecondIndex,
                               indicesA.ThirdIndex - indicesB.ThirdIndex);
        }

        public static TriangleIndices operator *(TriangleIndices indicesA, TriangleIndices indicesB)
        {
            return new TriangleIndices(indicesA.FirstIndex * indicesB.FirstIndex,
                               indicesA.SecondIndex * indicesB.SecondIndex,
                               indicesA.ThirdIndex * indicesB.ThirdIndex);
        }

        public static TriangleIndices operator /(TriangleIndices indicesA, TriangleIndices indicesB)
        {
            return new TriangleIndices(indicesA.FirstIndex / indicesB.FirstIndex,
                               indicesA.SecondIndex / indicesB.SecondIndex,
                               indicesA.ThirdIndex / indicesB.ThirdIndex);
        }

        public static TriangleIndices operator %(TriangleIndices indicesA, TriangleIndices indicesB)
        {
            return new TriangleIndices(indicesA.FirstIndex % indicesB.FirstIndex,
                               indicesA.SecondIndex % indicesB.SecondIndex,
                               indicesA.ThirdIndex % indicesB.ThirdIndex);
        }
    }
}