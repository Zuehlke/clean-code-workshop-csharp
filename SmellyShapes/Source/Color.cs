namespace SmellyShapes.Source
{
    public class Color
    {
        private readonly string colorAsText;

        public string ColorAsHex { get; private set; }
        public string ColorAsRgbBlue { get; private set; }
        public string ColorAsRgbGreen { get; private set; }
        public string ColorAsRgbRed { get; private set; }
        public string ErrorMessage { get; private set; }

        public Color(string colorAsText)
        {
            this.colorAsText = colorAsText;
            ConvertTextValueToRgbAndHex();
        }

        public string GetColorFormatted(bool includeHexAndRgb)
        {
            if (includeHexAndRgb)
                return colorAsText + " " + ColorAsHex + " " + ColorAsRgbRed + ":" + ColorAsRgbGreen + ":" +
                       ColorAsRgbBlue;
            return colorAsText;
        }

        private void ConvertTextValueToRgbAndHex()
        {
            ErrorMessage = "";
            // set to Red
            if ("Red" == colorAsText)
            {
                ColorAsRgbRed = "255";
                ColorAsRgbBlue = "0";
                ColorAsRgbGreen = "0";
                ColorAsHex = "#FF0000";
            }
            else if ("Blue" == colorAsText)
            {
                // set to Blue
                ColorAsRgbRed = "0";
                ColorAsRgbBlue = "255";
                ColorAsRgbGreen = "0";
                ColorAsHex = "#00FF00";
            }
            else if ("Green" == colorAsText)
            {
                // set to Green
                ColorAsRgbRed = "0";
                ColorAsRgbBlue = "0";
                ColorAsRgbGreen = "255";
                ColorAsHex = "#0000FF";
            }
            else
            {
                ErrorMessage = "Color not recognized";
            }
        }
    }
}