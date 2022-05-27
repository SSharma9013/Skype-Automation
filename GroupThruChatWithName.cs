using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkypeAutomation
{
    class GroupThruChatWithName
    {
        public void SendingMessagesToGroupWitName(IWebDriver d1, IWebDriver d2, IWebDriver d3, IWebDriver d4)
        {
            LocatingElements LocatingElements = new LocatingElements();
            SkypeBasicFeatures SkypeBasicFeatures = new SkypeBasicFeatures();
            miscellaneous miscellaneous = new miscellaneous();
            GroupClass GroupClass = new GroupClass();


            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            GroupClass.CreatingGroupWithoutName(d1);

            Thread.Sleep(8000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            miscellaneous.ClickOnLatestRecievedMessage(d2);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            miscellaneous.ClickOnLatestRecievedMessage(d1);
            Thread.Sleep(2000);
            SkypeBasicFeatures.SendingStartOfTestMessage(d1, "Group without name", ConfigurationManager.AppSettings.Get("Contact1Name"));
            SkypeBasicFeatures.SendingTextMessages(d1, "Group without name", ConfigurationManager.AppSettings.Get("Contact1Name"));
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.SendingTextMessages(d2, "Group without name", ConfigurationManager.AppSettings.Get("Contact2Name"));
            Thread.Sleep(2000);
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
            //LocatingElements.BringBrowserinFocus(d1, d2, d3, d4, 1);
            //LocatingElements.MakeCall(d1);
            //Thread.Sleep(8000);
            //LocatingElements.BringBrowserinFocus(d1, d2, d3, d4, 2);
            //LocatingElements.ReceavingCall(d2, ConfigurationManager.AppSettings.Get("Contact1Name"));
            //Thread.Sleep(20000);
            //LocatingElements.EndCall(d2);

            GroupClass.AddingContact(d1, "Suraksha Sharma");
            Thread.Sleep(5000);

            GroupClass.JoiningAGroup(d1, d2,d3,d4);
            Thread.Sleep(5000);

            GroupClass.RemovingContact(d1, "Suraksha Sharma");
            Thread.Sleep(5000);

            GroupClass.LeaveGroup(d4, ConfigurationManager.AppSettings.Get("Contact4Name"));
            Thread.Sleep(5000);

        }
    }
}
