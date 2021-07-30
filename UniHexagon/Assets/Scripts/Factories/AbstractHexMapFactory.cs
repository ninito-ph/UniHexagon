using UniHexagon.Interfaces;
using UniHexagon.Maps;

namespace UniHexagon
{
    public abstract class AbstractHexMapFactory
    {
        public abstract IHexMap Produce();
    }

    public class HexMapFactory : AbstractHexMapFactory
    {
        public override IHexMap Produce()
        {
            return new HexagonalHexMap();
        }
    }
}