using System.Collections.Generic;

namespace UniHexagon.Interfaces
{
    public interface IHexMap
    {
        public HashSet<IHex> Hexes { get; }

        public IEnumerable<IHex> GetValidNeighborsOf(IHex hex);
        public void Create(int radius);
        public void Clear();
    }
}