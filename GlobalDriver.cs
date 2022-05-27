using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeAutomation
{
    static class GlobalDriver
    {
        public static ChromeOptions options()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--use-fake-device-for-media-stream");
            chromeOptions.AddArgument("--use-fake-ui-for-media-stream");
            chromeOptions.AddArgument("--disable-notifications");
            //chromeOptions.AddArgument("--headless");

            return chromeOptions;

        }

        public static IWebDriver driver1 = new ChromeDriver(options());
        public static IWebDriver driver2 = new ChromeDriver(options());
        public static IWebDriver driver3 = new ChromeDriver(options());
        public static IWebDriver driver4 = new ChromeDriver(options());

    }
}

