using System.Collections.Generic;
using System.Linq;
using UniHexagon.Interfaces;
using UnityEngine;

namespace UniHexagon.Hexes
{
    /// <summary>
    ///     A hex container with axial coordinates
    /// </summary>
    public readonly struct Hex : IHex
    {
        #region Private Fields

        private static readonly AbstractHexFactory HexFactory = new HexFactory();

        private static Vector2Int[] Directions { get; } =
        {
            new Vector2Int(1, -1),
            new Vector2Int(1, 0),
            new Vector2Int(0, 1),
            new Vector2Int(-1, 1),
            new Vector2Int(-1, 0),
            new Vector2Int(0, -1)
        };

        #endregion

        #region Constructor

        public Hex(Vector2Int axialCoordinates)
        {
            AxialCoordinates = axialCoordinates;
        }

        #endregion

        #region IHex Implementation

        public Vector2Int AxialCoordinates { get; }

        public Vector3Int CubeCoordinates => new Vector3Int(AxialCoordinates.x, AxialCoordinates.y,
            -AxialCoordinates.x - AxialCoordinates.y);

        Vector2Int[] IHex.Directions => Directions;

        public IHex GetNeighborAtDirection(int directionIndex)
        {
            // NOTE: This boxing allocation may be a severe impediment for large-scale usage.
            // consider breaking the Interface Segregation Principle in this occasion for better performance
            return Add(this, HexFactory.Produce(Directions[directionIndex]));
        }

        public IHex Add(IHex a, IHex b)
        {
            return HexFactory.Produce(a.AxialCoordinates + b.AxialCoordinates);
        }

        public IHex Subtract(IHex a, IHex b)
        {
            return HexFactory.Produce(a.AxialCoordinates - b.AxialCoordinates);
        }

        public IHex Multiply(IHex a, IHex b)
        {
            return HexFactory.Produce(a.AxialCoordinates * b.AxialCoordinates);
        }

        public bool Equals(Vector2Int other)
        {
            return AxialCoordinates.Equals(other);
        }

        public override bool Equals(object obj)
        {
            return obj is Hex other && Equals(other.AxialCoordinates);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return AxialCoordinates.GetHashCode() * 397;
            }
        }

        public IEnumerable<IHex> GetNeighbors()
        {
            var neighbors = new List<IHex>();

            for (int direction = 0; direction < Directions.Length; direction++)
            {
                neighbors.Add(GetNeighborAtDirection(direction));
            }

            return neighbors;
        }

        public bool IsNeighborOf(IHex hex)
        {
            return GetNeighbors().Contains(hex);
        }

        public int GetOppositeSideOf(int side)
        {
            return (side + 3) % 6;
        }

        #endregion
    }
}