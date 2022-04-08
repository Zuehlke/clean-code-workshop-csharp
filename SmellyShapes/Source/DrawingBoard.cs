namespace SmellyShapes.Source;

public class DrawingBoard
{
    private readonly ShapeGroup shapeGroup = new();

    public Color BackgroundColor { get; set; }

    public static void Main()
    {
        var drawingBoard = new DrawingBoard
        {
            BackgroundColor = new Color("Green"),
        };

        drawingBoard.Add(new Square(-10, -10, 20));
        drawingBoard.Load("testFile");
        drawingBoard.DrawOnScreen();
    }

    public void Add(Shape shape)
    {
        shapeGroup.Add(shape);
    }

    public void DrawOnScreen()
    {
        // ... removed for exercise
    }

    public void Load(string file)
    {
        // ... removed for exercise
    }
}