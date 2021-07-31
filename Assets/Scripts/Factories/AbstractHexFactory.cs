using UniHexagon.Hexes;
using UniHexagon.Interfaces;
using UnityEngine;

namespace UniHexagon
{
    public abstract class AbstractHexFactory
    {
        public abstract IHex Produce(Vector2Int axialCoordinates);
    }

    public class HexFactory : AbstractHexFactory
    {
        public override IHex Produce(Vector2Int axialCoordinates)
        {
            return new Hex(axialCoordinates);
        }
    }
}