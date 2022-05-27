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
    class ModeratedGroup
    {
        public void SendingMessagesToModeratedGroup(IWebDriver d1, IWebDriver d2, IWebDriver d3, IWebDriver d4)
        {
            LocatingElements LocatingElements = new LocatingElements();
            SkypeBasicFeatures SkypeBasicFeatures = new SkypeBasicFeatures();
            miscellaneous miscellaneous = new miscellaneous();
            GroupClass GroupClass = new GroupClass();

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            Thread.Sleep(5000);
            GroupClass.CreatingGroupThruCons(d1, "Modgrp");
            Thread.Sleep(8000);
            GroupClass.GroupFunctionalities(d1, d2, d3, d4, "Modgrp");

        }
    }
}
