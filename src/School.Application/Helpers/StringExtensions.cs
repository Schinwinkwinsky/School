namespace School.Application.Helpers;

public static class StringExtensions
{
    public static string Capitalize(this string value)
    {
        return value[..1].ToUpper() + value[1..];
    }
}
