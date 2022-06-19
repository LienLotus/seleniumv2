namespace SeleniumFramework.Extensions
{
    public static class GeneralExtensionMethods
    {

        public static string Clean(this string str)
        {
            var cleaned = str.Replace("\t", "").Trim();
            return cleaned;
        }
    }
}
