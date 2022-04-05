using System;
using System.Text;

namespace SmellyShapes.Source
{
    public abstract class AbstractShape : IShape
    {
        public abstract bool Contains(int x, int y);

        public string ToXml()
        {
            var builder = new StringBuilder();

            if (this is Circle circle)
            {
                builder.Append("<circle");
                builder.Append(" x=\"" + circle.X + "\"");
                builder.Append(" y=\"" + circle.Y + "\"");
                builder.Append(" radius=\"" + circle.Radius + "\"");
                builder.Append(" />\n");
            }
            else if (this is Square)
            {
                var square = (Square) this;
                builder.Append("<square");
                builder.Append(" x=\"" + square.X + "\"");
                builder.Append(" y=\"" + square.Y + "\"");
                builder.Append(" edgeLength=\"" + square.Width + "\"");
                builder.Append(" />\n");
            }
            else if (this is Rectangle)
            {
                var rectangle = (Rectangle) this;
                builder.Append("<rectangle");
                builder.Append(" x=\"" + rectangle.X + "\"");
                builder.Append(" y=\"" + rectangle.Y + "\"");
                builder.Append(" width=\"" + rectangle.Width + "\"");
                builder.Append(" height=\"" + rectangle.Height + "\"");
                builder.Append(" />\n");
            }
            else if (this is ShapeGroup)
            {
                var group = (ShapeGroup) this;
                builder.Append("<shapegroup>\n");
                for (var i = 0; i < group.size; i++)
                    builder.Append(group.shapes[i].ToXml());
                builder.Append("</shapegroup>\n");
            }
            else
            {
                throw new ArgumentException("Unknown shape type: " + GetType());
            }

            return builder.ToString();
        }
    }
}