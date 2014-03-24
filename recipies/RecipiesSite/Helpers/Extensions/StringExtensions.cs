using System.Configuration;

namespace Helpers.Extensions
{
    public static class StringExtensions
    {
        public static string TrimToLength(this string stringToTrim)
        {
            if (ConfigurationManager.AppSettings["YordanRadGridColumnMaxVisualLength"] != null)
            {
                int yordanRadGridColumnMaxVisualLength =
                    int.Parse(ConfigurationManager.AppSettings["YordanRadGridColumnMaxVisualLength"]);
                string result = stringToTrim;
                if (stringToTrim.Length >= yordanRadGridColumnMaxVisualLength)
                {
                    result = stringToTrim.Substring(0, yordanRadGridColumnMaxVisualLength - 3) + "...";
                }
                return result;
            }
            return string.Empty;
        }
    }
}