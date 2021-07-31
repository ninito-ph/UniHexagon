using System;
using System.Collections.Generic;
using System.Linq;
using UniHexagon.Interfaces;
using UnityEngine;

namespace UniHexagon.Maps
{
    public class HexagonalHexMap : IHexMap
    {
        #region Private Fields

        protected static readonly AbstractHexFactory HexFactory = new HexFactory();

        public HashSet<IHex> Hexes { get; } = new HashSet<IHex>();

        #endregion

        #region IHexMap Implementation

        public virtual void Create(int radiusInHexes)
        {
            radiusInHexes--;
            
            if (radiusInHexes < 0) throw new InvalidOperationException("Radius must always be positive!");
            
            for (int qCoordinate = -radiusInHexes; qCoordinate <= radiusInHexes; qCoordinate++)
            {
                int r1 = Mathf.Max(-radiusInHexes, -qCoordinate - radiusInHexes);
                int r2 = Mathf.Min(radiusInHexes, -qCoordinate + radiusInHexes);

                for (int rCoordinate = r1; rCoordinate <= r2; rCoordinate++)
                {
                    MakeAndAddHex(new Vector2Int(qCoordinate, rCoordinate));
                }
            }
        }
        
        public IEnumerable<IHex> GetValidNeighborsOf(IHex hex)
        {
            return FilterInvalidHexesFrom(hex.GetNeighbors());
        }

        public virtual void Clear() => Hexes.Clear();

        #endregion

        #region Protected Methods

        protected virtual void MakeAndAddHex(Vector2Int axialCoordinates)
        {
            IHex newHex = HexFactory.Produce(axialCoordinates);
            Hexes.Add(newHex);
        }
        
        protected IEnumerable<IHex> FilterInvalidHexesFrom(IEnumerable<IHex> hexEnumerable)
        {
            return hexEnumerable.Intersect(Hexes);
        }

        #endregion
    }
}