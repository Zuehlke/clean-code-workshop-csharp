namespace SmellyShapes.Source
{
    public abstract class ComplexShape : AbstractShape
    {
        protected bool ReadOnly { get; set; }

        public void SetReadOnly(bool readOnly)
        {
            ReadOnly = readOnly;
        }
    }
}