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
    class miscellaneous
    {
        //SignIn related Elements names
        String EmailInput = "loginfmt";
        //readonly String SignInButton = "idSIButton9";
        String PasswordInput = "passwd";

        //Notifications Related Elements
        String Crossbuttton = "'Close'";
        String moodmessage = "'Edit mood message'";

        //Sign in function which will input the email and password click next and sign into the skype account
        //---------------------------------******************-------------------------------------

        LocatingElements LocatingElements = new LocatingElements();


        public void PreparationForTest(IWebDriver d1, IWebDriver d2, IWebDriver d3, IWebDriver d4)
        {

            // navigate to URL
            d1.Navigate().GoToUrl("https://web.skype.com/");
            d2.Navigate().GoToUrl("https://web.skype.com/");
            d3.Navigate().GoToUrl("https://web.skype.com/");
            d4.Navigate().GoToUrl("https://web.skype.com/");

            LocatingElements LocatingElements = new LocatingElements();


            BringBrowserinFocus(d1, d2, d3, d4, 1);
            //Signin to the 1st Account
            SignIn(d1,ConfigurationManager.AppSettings.Get("Id1"),ConfigurationManager.AppSettings.Get("Pw1"));
            Thread.Sleep(2000);
            //Signin to the 2nd Account
            BringBrowserinFocus(d1, d2, d3, d4, 2);
            SignIn(d2, ConfigurationManager.AppSettings.Get("Id2"), ConfigurationManager.AppSettings.Get("Pw2"));
            Thread.Sleep(2000);

            //Signin to the 3rd Account
            BringBrowserinFocus(d1, d2, d3, d4, 3);
            SignIn(d3, ConfigurationManager.AppSettings.Get("Id3"), ConfigurationManager.AppSettings.Get("Pw3"));
            Thread.Sleep(2000);
            //Signin to the 2nd Account
            BringBrowserinFocus(d1, d2, d3, d4, 4);
            SignIn(d4, ConfigurationManager.AppSettings.Get("Id4"), ConfigurationManager.AppSettings.Get("Pw4"));
            Thread.Sleep(2000);




            //Disabling the Notifications
            BringBrowserinFocus(d1, d2, d3, d4, 1);
            RemoveNotification(d1);
            Thread.Sleep(2000);
            BringBrowserinFocus(d1, d2, d3, d4, 2);
            RemoveNotification(d2);
            Thread.Sleep(2000);

            BringBrowserinFocus(d1, d2, d3, d4, 3);
            RemoveNotification(d3);
            BringBrowserinFocus(d1, d2, d3, d4, 4);
            Thread.Sleep(5000);
            RemoveNotification(d4);
            Thread.Sleep(2000);

        }

        public void SignIn(IWebDriver Driver, String Id, String Pw)
        {

            LocatingElements.LocatingElementsByName(Driver, EmailInput).SendKeys(Id);
            LocatingElements.LocatingElementsByName(Driver, EmailInput).SendKeys(Keys.Enter);
            //Thread.Sleep(1000);


            //Entering the password
            LocatingElements.LocatingElementsByName(Driver, PasswordInput).SendKeys(Pw);
            Thread.Sleep(5000);
            //Clicking on next button
            LocatingElements.LocatingElementsByName(Driver, PasswordInput).SendKeys(Keys.Enter);


            //Clicking on Signin button
            //LocatingElementsById(Driver, SignInButton).Click();
            //Thread.Sleep(5000);

        }


        //As soon as WeakReference loginto skype there are several popups which need to be closed this function does the job of closing them
        //-----------------------------************************-------------------------------
        public void RemoveNotification(IWebDriver Driver)
        {

            LocatingElements.LocatingElementsByariaLabel(Driver, moodmessage, "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, Crossbuttton, "button").Click();
        }

        //Selecting  Contacts to from search by typing particular name
        //---------------------------------******************-------------------------------------
        public void SelectingContact(IWebDriver Driver, string ContactName, String ChatType)
        {
            //Chat related Elements
            String Search1 = "'Search for people, groups & messages'";
            String Search2 = "'Search Skype'";

            if (ChatType == "Group")
            {
                String OpeningContact = "//div[@role= 'button' and @tabindex= '0'and @style='position: relative; display: flex; flex-direction: column; flex-grow: 0; flex-shrink: 0; overflow: visible; align-items: stretch; cursor: pointer; height: 56px;']";
                LocatingElements.LocatingElementsByariaLabel(Driver, Search1, "button").Click();
                Thread.Sleep(5000);
                LocatingElements.LocatingElementsByariaLabel(Driver, Search2, "input").SendKeys(ContactName);
                Thread.Sleep(5000);
                LocatingElements.LocatingElementsByarialabel(Driver, OpeningContact).Click();
                Thread.Sleep(8000);
                LocatingElements.LocatingElementsByariaLabel(Driver, "'Close search'", "button").Click();

            }
            else if (ChatType == "P2P")
            {
                String OpeningContact = "//div[@role= 'button' and @tabindex= '0'and @style='position: relative; display: flex; flex-direction: column; flex-grow: 0; flex-shrink: 0; overflow: visible; align-items: stretch; cursor: pointer;']";
                LocatingElements.LocatingElementsByariaLabel(Driver, Search1, "button").Click();
                Thread.Sleep(5000);
                LocatingElements.LocatingElementsByariaLabel(Driver, Search2, "input").SendKeys(ContactName);
                Thread.Sleep(5000);
                LocatingElements.LocatingElementsByarialabel(Driver, OpeningContact).Click();
                Thread.Sleep(8000);
                LocatingElements.LocatingElementsByariaLabel(Driver, "'Close search'", "button").Click();
            }




        }

        public void BringBrowserinFocus(IWebDriver D1, IWebDriver D2, IWebDriver D3, IWebDriver D4, int BrowserNumber)
        {
            switch (BrowserNumber)
            {
                case 1:
                    {
                        Console.WriteLine("Bringing browser 1 in Focus");
                        D2.Manage().Window.Minimize();
                        D3.Manage().Window.Minimize();
                        D4.Manage().Window.Minimize();
                        D1.Manage().Window.Maximize();
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Bringing browser 2 in Focus");
                        D1.Manage().Window.Minimize();
                        D3.Manage().Window.Minimize();
                        D4.Manage().Window.Minimize();
                        D2.Manage().Window.Maximize();
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Bringing browser 3 in Focus");
                        D1.Manage().Window.Minimize();
                        D2.Manage().Window.Minimize();
                        D4.Manage().Window.Minimize();
                        D3.Manage().Window.Maximize();
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Bringing browser 4 in Focus");
                        D1.Manage().Window.Minimize();
                        D2.Manage().Window.Minimize();
                        D3.Manage().Window.Minimize();
                        D4.Manage().Window.Maximize();
                        break;
                    }


            }

        }

        //Clicking on the 1st recieved message
        public void ClickOnLatestRecievedMessage(IWebDriver Driver)
        {
            String LatestRecievedMessage = "//div[@role='button' and @tabindex='-1']";
            LocatingElements.LocatingElementsByarialabel(Driver, LatestRecievedMessage).Click();

        }
    }
}
