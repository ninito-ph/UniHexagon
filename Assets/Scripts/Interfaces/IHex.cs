using System;
using System.Collections.Generic;
using UnityEngine;

namespace UniHexagon.Interfaces
{
    public interface IHex : IEquatable<Vector2Int>, ISimpleVectorArithmetic<IHex>
    {
        public Vector2Int AxialCoordinates { get; }
        public Vector3Int CubeCoordinates { get; }
        public Vector2Int[] Directions { get; }

        public IEnumerable<IHex> GetNeighbors();
        public bool IsNeighborOf(IHex hex);
        public IHex GetNeighborAtDirection(int directionIndex);

        public int GetOppositeSideOf(int side);
    }
}