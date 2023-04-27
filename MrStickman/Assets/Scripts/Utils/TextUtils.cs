public static class TextUtils
{
    public static string Color(this string str, string color) => $"<color={color}>{str}</color>";
    public static string Size(this string str, int sizeMultiplier) => $"<size={12 + sizeMultiplier}>{str}</size>";
    public static string Bold(this string str) => $"<bold>{str}</bold>";
    public static string Italic(this string str) => $"<i>{str}</i>";
}
