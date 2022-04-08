namespace SmellyShapes.Source;

public class Color
{
    private const string Red = "Red";
    private const string Blue = "Blue";
    private const string Green = "Green";

    public Color(string colorAsText)
    {
        ColorAsText = colorAsText;
        ConvertTextValueToRgbAndHex();
    }

    public string ColorAsText { get; }

    public string ColorAsHex { get; private set; }

    public string ColorAsRgbBlue { get; private set; }

    public string ColorAsRgbGreen { get; private set; }

    public string ColorAsRgbRed { get; private set; }

    public string ErrorMessage { get; private set; }

    public override string ToString()
    {
        return "RGB=" + ColorAsRgbRed + ","
               + ColorAsRgbGreen + ","
               + ColorAsRgbBlue;
    }

    public string GetColorFormatted(bool includeHexAndRgb)
    {
        return includeHexAndRgb ? GetColorFormatted() : ColorAsText;
    }

    public string GetColorFormatted()
    {
        return ColorAsText + " " + ColorAsHex + " " + ColorAsRgbRed + ":" + ColorAsRgbGreen + ":" +
               ColorAsRgbBlue;
    }

    private void ConvertTextValueToRgbAndHex()
    {
        ErrorMessage = string.Empty;

        if (ColorAsText == Red)
        {
            ColorAsRgbRed = "255";
            ColorAsRgbBlue = "0";
            ColorAsRgbGreen = "0";
            ColorAsHex = "#FF0000";
        }
        else if (ColorAsText == Blue)
        {
            ColorAsRgbRed = "0";
            ColorAsRgbBlue = "255";
            ColorAsRgbGreen = "0";
            ColorAsHex = "#00FF00";
        }
        else if (ColorAsText == Green)
        {
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