namespace SmellyShapes.Source
{
    public class Circle : SimpleShape
    {
        private int numberOfContainingPoints;

        public Circle(int x, int y, int radius)
        {
            this.X = x;
            Y = y;
            this.Radius = radius;
        }

        /// <summary>
        ///     The shape color
        /// </summary>
        public Color Color { get; set; } = new Color("Green");

        public int X { get; }

        public int Y { get; }

        public int Radius { get; }

        public override bool Contains(int x, int y)
        {
            var result = (x - this.X) * (x - this.X) + (y - Y) * (y - Y) <= Radius * Radius;
            // Increase number of Points?
            if (result) numberOfContainingPoints++;
            return result;
        }

        public int CountContainingPoints(int[] xCords, int[] yCords)
        {
            numberOfContainingPoints = 0;
            for (var i = 0; i < xCords.Length; ++i) Contains(xCords[i], yCords[i]);
            return numberOfContainingPoints;
        }

        public override string ToString()
        {
            return "Circle: (" + X + "," + Y + ") radius= " + Radius
                   + " RGB=" + Color.GetColorAsRGBRed() + ","
                   + Color.GetColorAsRGBGreen() + ","
                   + Color.GetColorAsRGBBlue();
        }
    }
}