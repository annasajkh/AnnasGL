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
            return $"Triangle Indices: [{FirstIndex}, {SecondIndex}, {ThirdIndex}]";
        }

        public static TriangleIndices operator +(TriangleIndices TriangleIndicesA, TriangleIndices TriangleIndicesB)
        {
            return new TriangleIndices(TriangleIndicesA.FirstIndex + TriangleIndicesB.FirstIndex,
                                       TriangleIndicesA.SecondIndex + TriangleIndicesB.SecondIndex,
                                       TriangleIndicesA.ThirdIndex + TriangleIndicesB.ThirdIndex);
        }

        public static TriangleIndices operator -(TriangleIndices TriangleIndicesA, TriangleIndices TriangleIndicesB)
        {
            return new TriangleIndices(TriangleIndicesA.FirstIndex - TriangleIndicesB.FirstIndex,
                                       TriangleIndicesA.SecondIndex - TriangleIndicesB.SecondIndex,
                                       TriangleIndicesA.ThirdIndex - TriangleIndicesB.ThirdIndex);
        }

        public static TriangleIndices operator *(TriangleIndices TriangleIndicesA, TriangleIndices TriangleIndicesB)
        {
            return new TriangleIndices(TriangleIndicesA.FirstIndex * TriangleIndicesB.FirstIndex,
                                       TriangleIndicesA.SecondIndex * TriangleIndicesB.SecondIndex,
                                       TriangleIndicesA.ThirdIndex * TriangleIndicesB.ThirdIndex);
        }

        public static TriangleIndices operator /(TriangleIndices TriangleIndicesA, TriangleIndices TriangleIndicesB)
        {
            return new TriangleIndices(TriangleIndicesA.FirstIndex / TriangleIndicesB.FirstIndex,
                                       TriangleIndicesA.SecondIndex / TriangleIndicesB.SecondIndex,
                                       TriangleIndicesA.ThirdIndex / TriangleIndicesB.ThirdIndex);
        }

        public static TriangleIndices operator %(TriangleIndices TriangleIndicesA, TriangleIndices TriangleIndicesB)
        {
            return new TriangleIndices(TriangleIndicesA.FirstIndex % TriangleIndicesB.FirstIndex,
                                       TriangleIndicesA.SecondIndex % TriangleIndicesB.SecondIndex,
                                       TriangleIndicesA.ThirdIndex % TriangleIndicesB.ThirdIndex);
        }
    }
}