using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkypeAutomation
{
    class Driver
    {
        //this function is to add options to th echrome drivers which will help to hide pop ups
        public static ChromeOptions options()
        {

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--use-fake-device-for-media-stream");
            chromeOptions.AddArgument("--use-fake-ui-for-media-stream");
            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArguments("--disable-backgrounding-occluded-windows");
            //chromeOptions.AddArgument("--headless");


            return chromeOptions;

        }

        public IWebDriver driver1 = new ChromeDriver(options());
        public IWebDriver driver2 = new ChromeDriver(options());
        public IWebDriver driver3 = new ChromeDriver(options());
        public IWebDriver driver4 = new ChromeDriver(options());

    }
}
