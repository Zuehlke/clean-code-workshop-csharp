namespace SmellyShapes.Source
{
    public class ShapeGroup : ComplexShape
    {
        public IShape[] shapes = new IShape[10];

        public int size;

        public ShapeGroup()
        {
        }

        public ShapeGroup(IShape[] shapes, bool readOnly)
        {
            this.shapes = shapes;
            size = shapes.Length;
            ReadOnly = readOnly;
        }

        public void Add(IShape shape)
        {
            if (!ReadOnly)
            {
                var newSize = size + 1;
                if (newSize > shapes.Length)
                {
                    var newShapes = new IShape[shapes.Length + 10];
                    for (var i = 0; i < size; i++) newShapes[i] = shapes[i];
                    shapes = newShapes;
                }

                if (Contains(shape)) return;
                shapes[size++] = shape;
            }
        }

        public bool Contains(IShape shape)
        {
            for (var i = 0; i < size; i++)
                if (shapes[i].Equals(shape))
                    return true;
            return false;
        }

        public override bool Contains(int x, int y)
        {
            foreach (var shape in shapes)
                if (shape != null)
                    if (shape.Contains(x, y))
                        return true;
            return false;
        }
    }
}