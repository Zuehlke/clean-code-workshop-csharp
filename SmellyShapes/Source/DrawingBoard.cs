using System;

namespace SmellyShapes.Source
{
    public class DrawingBoard : ShapeGroup
    {
        /// <summary>
        ///     Use NO_DATE to indicate that no date is set (the equivalent of 'null Date' in Java)
        /// </summary>
        public static readonly DateTime NO_DATE = DateTime.MaxValue;

        public Color BackgroundColor { get; set; }

        public void DrawOnScreen()
        {
            var previousStart = NO_DATE;
            var thisStart = DateTime.Now;
            Console.WriteLine("Started DrawOnScreen last time: " + previousStart);

            // ... removed for exercise
        }

        public void Load(string file)
        {
            // ... removed for exercise
        }

        public static void Main(string[] args)
        {
            var drawingBoard = new DrawingBoard();
            drawingBoard.BackgroundColor = new Color("Green");
            drawingBoard.Add(new Square(-10, -10, 20));
            drawingBoard.Load("testFile");
            drawingBoard.DrawOnScreen();
        }
    }
}