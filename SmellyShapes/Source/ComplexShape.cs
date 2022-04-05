namespace SmellyShapes.Source
{
    public abstract class ComplexShape : AbstractShape
    {
        protected bool ReadOnly;

        public void SetReadOnly(bool readOnly)
        {
            ReadOnly = readOnly;
        }
    }
}