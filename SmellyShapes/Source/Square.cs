using System;

namespace SmellyShapes.Source
{
    public class Square : Rectangle
    {
        public Square(int x, int y, int edgeLength)
            : base(x, y, edgeLength, edgeLength)
        {
        }

        public Square(int x, int y, int edgeLength, Color color)
            : base(x, y, edgeLength, edgeLength)
        {
            c = color;
        }

        public override int Height =>
            throw new InvalidOperationException("Square does not have a height, only edgeLength");

        public bool ContainsPoint(int x, int y)
        {
            return X <= x && x <= X + Width && Y <= y && y <= Y + Width;
        }

        public override string ToString()
        {
            return $"Square: ({X}:{Y}) edgeLength={Width} color={c.ColorAsHex}";
        }

        public bool Contains(int x1, int y1, int x2, int y2)
        {
            return Contains(x1, y1) && Contains(x2, y2);
        }
    }
}