namespace SmellyShapes.Source
{
    public class ShapeGroup : ComplexShape
    {
        public IShape[] Shapes = new IShape[10];

        public int Size;

        public ShapeGroup()
        {
        }

        public ShapeGroup(IShape[] shapes, bool readOnly)
        {
            this.Shapes = shapes;
            Size = shapes.Length;
            ReadOnly = readOnly;
        }

        public void Add(IShape shape)
        {
            if (!ReadOnly)
            {
                var newSize = Size + 1;
                if (newSize > Shapes.Length)
                {
                    var newShapes = new IShape[Shapes.Length + 10];
                    for (var i = 0; i < Size; i++) newShapes[i] = Shapes[i];
                    Shapes = newShapes;
                }

                if (Contains(shape)) return;
                Shapes[Size++] = shape;
            }
        }

        public bool Contains(IShape shape)
        {
            for (var i = 0; i < Size; i++)
                if (Shapes[i].Equals(shape))
                    return true;
            return false;
        }

        public override bool Contains(int x, int y)
        {
            foreach (var shape in Shapes)
                if (shape != null)
                    if (shape.Contains(x, y))
                        return true;
            return false;
        }
    }
}