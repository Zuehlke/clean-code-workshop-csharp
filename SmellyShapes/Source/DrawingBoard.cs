namespace SmellyShapes.Source
{
    public class DrawingBoard : ShapeGroup
    {
        /// <summary>
        ///     Use NoDate to indicate that no date is set (the equivalent of 'null Date' in Java)
        /// </summary>
        public static readonly DateTime NoDate = DateTime.MaxValue;

        public Color BackgroundColor { get; set; }

        public static void Main()
        {
            var drawingBoard = new DrawingBoard
            {
                BackgroundColor = new Color("Green")
            };

            drawingBoard.Add(new Square(-10, -10, 20));
            drawingBoard.Load("testFile");
            drawingBoard.DrawOnScreen();
        }

        public void DrawOnScreen()
        {
            var previousStart = NoDate;
            var thisStart = DateTime.Now;
            Console.WriteLine("Started DrawOnScreen last time: " + previousStart);

            // ... removed for exercise
        }

        public void Load(string file)
        {
            // ... removed for exercise
        }
    }
}