using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkypeAutomation
{


    public class SkypeBasicFeatures
    {
        LocatingElements LocatingElements = new LocatingElements();

        //Selecting GIFs/Moji/Sticker
        String Select = "//button[@role= 'button' and @tabindex= '0'and @style='position: relative; display: flex; flex-direction: column; flex-grow: 0; flex-shrink: 0; overflow: hidden; align-items: stretch; justify-content: center; background-color: transparent; border-color: rgba(0, 0, 0, 0); text-align: left; border-width: 2px; border-radius: 4px; border-style: solid; padding: 1px; cursor: pointer;']";

        //Xpath for more options in a chat window
        String MoreOptions = "//button[@aria-label='More options' and not(@tabindex='-1') and not(@Title ='More')]";

       

        public void SendingTextMessages(IWebDriver Driver, String ContactType, String ContactName)
        {
            
            IWebElement element = LocatingElements.LocatingElementsByariaLabel(Driver, "'Type a message'", "div");
            for (int i = 1; i < 2; i++)
            {
                element.SendKeys("Skype " + ConfigurationManager.AppSettings.Get("SkypeVersion") + " " + ConfigurationManager.AppSettings.Get("IMPMVersion") + ContactType + " Message" + i + " from " + ContactName + (Keys.Enter));
            }

        }

        public void SendingStartOfTestMessage(IWebDriver Driver, String ContactType, String ContactName)
        {
            
            IWebElement element = LocatingElements.LocatingElementsByariaLabel(Driver, "'Type a message'", "div");
            element.SendKeys("---Skype " + ConfigurationManager.AppSettings.Get("SkypeVersion") + " " + ConfigurationManager.AppSettings.Get("IMPMVersion") + ContactType + " Test Start---" + (Keys.Enter));
        }

        public void SendingCustomMessage(IWebDriver Driver, String MessageText)
        {
            IWebElement element = LocatingElements.LocatingElementsByariaLabel(Driver, "'Type a message'", "div");
            element.SendKeys(MessageText + (Keys.Enter));
        }

        public void SendingEndOfTestMessage(IWebDriver Driver, String ContactType, String ContactName)
        {
            
            IWebElement element = LocatingElements.LocatingElementsByariaLabel(Driver, "'Type a message'", "div");
            element.SendKeys("---Skype " + ConfigurationManager.AppSettings.Get("SkypeVersion") + " " + ConfigurationManager.AppSettings.Get("IMPMVersion") + ContactType + " Test End---" + (Keys.Enter));

        }



        public void SendingEmoticons(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Open Expression picker'", "button").Click();
            Thread.Sleep(10000);
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Weary'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Envy'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Global Learning'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Day of the dead'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Pumpkin'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Send message'", "button").Click();

        }

        public void SendingGIFs(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Open Expression picker'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'GIFs'", "button").Click();
            Thread.Sleep(20000);
            LocatingElements.LocatingElementsByarialabel(Driver, Select).Click();

        }

        public void SendingStickers(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Open Expression picker'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Stickers'", "button").Click();
            Thread.Sleep(20000);
            LocatingElements.LocatingElementsByarialabel(Driver, Select).Click();

        }

        public void SendingMojis(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Open Expression picker'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Mojis'", "button").Click();
            Thread.Sleep(20000);
            LocatingElements.LocatingElementsByarialabel(Driver, Select).Click();

        }

        public void SendingContacts(IWebDriver Driver)
        {
            //Sending Contacts to a Chat
            String SelectContacts = " //button[@role='button' and @tabindex='-1' and @style='position: relative; display: flex; flex-direction: column; flex-grow: 1; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: center; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; margin-left: 10px; margin-right: 10px; padding: 0px; cursor: pointer; border-style: solid;' ]";
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Send contacts to this chat'", "button").Click();
            Thread.Sleep(10000);

            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacts).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Send'", "button").Click();

        }

        public void CreatinPoll(IWebDriver Driver)
        {

            LocatingElements.LocatingElementsByarialabel(Driver, MoreOptions).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Create Poll, Create a poll'", "div").Click();
            LocatingElements.LocatingElementsByPlaceholder(Driver, "\"What's your poll question?\"", "input").SendKeys("Who will win US Election?");
            LocatingElements.LocatingElementsByPlaceholder(Driver, "\"Option 1\"", "input").SendKeys("Biden");
            LocatingElements.LocatingElementsByPlaceholder(Driver, "\"Option 2\"", "input").SendKeys("Trump");
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Create poll'", "button").Click();

        }
        public void SchedulingCall(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByarialabel(Driver, MoreOptions).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Schedule a Call, Arrange a Skype call and get reminders'", "div").Click();
            LocatingElements.LocatingElementsByPlaceholder(Driver, "\"Title\"", "input").SendKeys("Scheduled Call");
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Send'", "button").Click();

        }


        public void SendingLanguages(IWebDriver Driver)
        {
            IWebElement element = LocatingElements.LocatingElementsByariaLabel(Driver, "'Type a message'", "div");
            string address = "languages.txt";
            foreach (string line in File.ReadLines(address, Encoding.UTF8))
            {
                String string1 = line;
                element.SendKeys(string1 + (Keys.Enter));

            }

        }


        public void MakeCall(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Audio Call'", "button").Click();
        }

        public void ReceavingCall(IWebDriver Driver, String Contact)
        {
            String contactAriaLabel = "'Answer call from " + Contact + " with voice only'";
            LocatingElements.LocatingElementsByariaLabel(Driver, contactAriaLabel, "button").Click();

        }

        public void EndCall(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'End Call'", "button").Click();

        }


        public void UploadingFiles(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Add files'", "button").Click();
            Thread.Sleep(2000);
            Process myProcess = new Process();
            myProcess.StartInfo.UseShellExecute = false;
            myProcess.StartInfo.FileName = "AutoItScriptToUploadFiles.exe";
            myProcess.StartInfo.CreateNoWindow = true;
            myProcess.Start();
            TimeSpan interval = TimeSpan.FromSeconds(30);
            WebDriverWait wait = new WebDriverWait(Driver, interval);


            for (int i = 1; i < 14; i++)
            {
                //var example2 = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath("//button[@aria-label = 'Send message']")));
                Thread.Sleep(3000);
                LocatingElements.LocatingElementsByariaLabel(Driver, "'Send message'", "button").Click();
                LocatingElements.LocatingElementsByariaLabel(Driver, "'Add files'", "button").Click();
                Console.Write("sent test" + i);
                Thread.Sleep(2000);

            }
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Send message'", "button").Click();

        }



    }
}
