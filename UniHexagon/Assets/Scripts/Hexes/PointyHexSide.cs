using System;

namespace UniHexagon.Hexes
{
    [Serializable]
    public enum PointyHexSide
    {
        // Sides can be equated to a number, obtained by counting them clockwise, starting with 0
        TopRight = 0,
        Right = 1,
        BottomRight = 2,
        BottomLeft = 3,
        Left = 4,
        TopLeft = 5
    }
}