using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SkypeAutomation;
using System.Security.Cryptography;

using System.IO;
using OpenQA.Selenium.Remote;
using System.Configuration;
using System.Collections.Specialized;
using WebDriverManager.DriverConfigs.Impl;


namespace SkypeAutomation
{
    

    public class AutomainMain
    {

        //main Function
        static void Main(string[] args)
        {
            

            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            //Start of the test
            Console.Write("started of the test ");
            //Object Instance for LocatingElements
            LocatingElements LocatingElements = new LocatingElements();
            miscellaneous miscellaneous = new miscellaneous();
            P2PClass P2PClass = new P2PClass();
            GroupWithoutNameClass GroupWithoutNameClass = new GroupWithoutNameClass();
            GroupThruContacts GroupThruContacts = new GroupThruContacts();
            ModeratedGroup ModeratedGroup = new ModeratedGroup();

            IWebDriver d1 = GlobalDriver.driver1;
            IWebDriver d2 = GlobalDriver.driver2;
            IWebDriver d3 = GlobalDriver.driver3;
            IWebDriver d4 = GlobalDriver.driver4;

            miscellaneous.PreparationForTest(d1,d2,d3,d4);

            P2PClass.SendingP2PMessages(d1, d2, d3, d4);
            
            GroupWithoutNameClass.SendingMessagesToGroupWithoutName(d1, d2, d3, d4);

            GroupThruContacts.SendingMessagesToGroupWitName(d1, d2, d3, d4);

            ModeratedGroup.SendingMessagesToModeratedGroup(d1, d2, d3, d4);


        }


    }
}
