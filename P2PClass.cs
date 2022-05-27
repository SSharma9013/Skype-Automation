using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace SkypeAutomation
{
    public class P2PClass
    {


        public void SendingP2PMessages(IWebDriver d1, IWebDriver d2, IWebDriver d3, IWebDriver d4)
        {


            LocatingElements LocatingElements = new LocatingElements();
            miscellaneous miscellaneous = new miscellaneous();
            SkypeBasicFeatures SkypeBasicFeatures = new SkypeBasicFeatures();

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            miscellaneous.SelectingContact(d1, ConfigurationManager.AppSettings.Get("Contact2Name"), "P2P");
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            SkypeBasicFeatures.SendingStartOfTestMessage(d1, "P2P ", ConfigurationManager.AppSettings.Get("Contact1Name"));
            SkypeBasicFeatures.SendingTextMessages(d1, "P2P ", ConfigurationManager.AppSettings.Get("Contact1Name"));
            
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            miscellaneous.SelectingContact(d2, ConfigurationManager.AppSettings.Get("Contact1Name"), "P2P");
            Thread.Sleep(2000);
            SkypeBasicFeatures.SendingTextMessages(d2, "P2P ", ConfigurationManager.AppSettings.Get("Contact2Name"));
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            SkypeBasicFeatures.SendingEmoticons(d1);
            SkypeBasicFeatures.SendingGIFs(d1);
            SkypeBasicFeatures.SendingMojis(d1);
            SkypeBasicFeatures.SendingStickers(d1);
            SkypeBasicFeatures.SendingContacts(d1);
            Thread.Sleep(2000);
            SkypeBasicFeatures.CreatinPoll(d1);
            Thread.Sleep(2000);
            SkypeBasicFeatures.SchedulingCall(d1);
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.SendingLanguages(d2);
            Thread.Sleep(2000);
            SkypeBasicFeatures.UploadingFiles(d2);
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            SkypeBasicFeatures.MakeCall(d1);
            Thread.Sleep(10000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.ReceavingCall(d2, ConfigurationManager.AppSettings.Get("Contact1Name"));
            Thread.Sleep(20000);
            SkypeBasicFeatures.EndCall(d2);
        }

    }
}
