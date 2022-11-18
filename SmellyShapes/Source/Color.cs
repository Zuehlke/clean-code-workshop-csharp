namespace SmellyShapes.Source
{
    public class Color
    {
        private readonly string colorAsText;

        public string ColorAsHex { get; private set; }
        public string ColorAsRGBBlue { get; private set; }
        public string ColorAsRGBGreen { get; private set; }
        public string ColorAsRGBRed { get; private set; }
        public string ErrorMessage { get; private set; }

        public Color(string colorAsText)
        {
            this.colorAsText = colorAsText;
            ConvertTextValueToRGBAndHex();
        }

        private void ConvertTextValueToRGBAndHex()
        {
            ErrorMessage = "";
            // set to Red
            if ("Red" == colorAsText)
            {
                ColorAsRGBRed = "255";
                ColorAsRGBBlue = "0";
                ColorAsRGBGreen = "0";
                ColorAsHex = "#FF0000";
            }
            else if ("Blue" == colorAsText)
            {
                // set to Blue
                ColorAsRGBRed = "0";
                ColorAsRGBBlue = "255";
                ColorAsRGBGreen = "0";
                ColorAsHex = "#00FF00";
            }
            else if ("Green" == colorAsText)
            {
                // set to Green
                ColorAsRGBRed = "0";
                ColorAsRGBBlue = "0";
                ColorAsRGBGreen = "255";
                ColorAsHex = "#0000FF";
            }
            else
            {
                ErrorMessage = "Color not recognized";
            }
        }

        public string GetColorFormatted(bool includeHexAndRGB)
        {
            if (includeHexAndRGB)
                return colorAsText + " " + ColorAsHex + " " + ColorAsRGBRed + ":" + ColorAsRGBGreen + ":" +
                       ColorAsRGBBlue;
            return colorAsText;
        }
    }
}