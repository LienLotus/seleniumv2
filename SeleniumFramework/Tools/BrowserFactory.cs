namespace SeleniumFramework.Tools
{
    public class BrowserFactory
    {
        public static Browser Instance
        {
            get
            {
                return new Browser();
            }
        }
    }
}
