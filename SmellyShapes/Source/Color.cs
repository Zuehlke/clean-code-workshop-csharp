namespace SmellyShapes.Source
{
    public class Color
    {
        private string colorAsHex;
        private string colorAsRGB_Blue;
        private string colorAsRGB_Green;
        private string colorAsRGB_Red;
        private readonly string colorAsText;
        private string errorMessage;

        public Color(string colorAsText)
        {
            this.colorAsText = colorAsText;
            ConvertTextValueToRGBAndHex();
        }

        private void ConvertTextValueToRGBAndHex()
        {
            errorMessage = "";
            // set to Red
            if ("Red".Equals(colorAsText))
            {
                colorAsRGB_Red = "255";
                colorAsRGB_Blue = "0";
                colorAsRGB_Green = "0";
                colorAsHex = "#FF0000";
            }
            else if ("Blue".Equals(colorAsText))
            {
                // set to Blue
                colorAsRGB_Red = "0";
                colorAsRGB_Blue = "255";
                colorAsRGB_Green = "0";
                colorAsHex = "#00FF00";
            }
            else if ("Green".Equals(colorAsText))
            {
                // set to Green
                colorAsRGB_Red = "0";
                colorAsRGB_Blue = "0";
                colorAsRGB_Green = "255";
                colorAsHex = "#0000FF";
            }
            else
            {
                errorMessage = "Color not recognized";
            }
        }

        public string GetColorAsRGBBlue()
        {
            return colorAsRGB_Blue;
        }

        public string GetColorAsRGBGreen()
        {
            return colorAsRGB_Green;
        }

        public string GetColorAsRGBRed()
        {
            return colorAsRGB_Red;
        }

        public string GetErrorMessage()
        {
            return errorMessage;
        }

        public string GetColorFormatted(bool includeHexAndRGB)
        {
            if (includeHexAndRGB)
                return colorAsText + " " + colorAsHex + " " + colorAsRGB_Red + ":" + colorAsRGB_Green + ":" +
                       colorAsRGB_Blue;
            return colorAsText;
        }

        public string GetColorAsHex()
        {
            return colorAsHex;
        }
    }
}