using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkypeAutomation
{
    class GroupClass
    {
        LocatingElements LocatingElements = new LocatingElements();
        SkypeBasicFeatures SkypeBasicFeatures = new SkypeBasicFeatures();
        miscellaneous miscellaneous = new miscellaneous();

        public void CreatingGroupWithoutName(IWebDriver Driver)
        {


            String SelectContacttoAdd = "//button[@role='button' and @tabindex='-1' and @style='position: relative; display: flex; flex-direction: column; flex-grow: 1; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: center; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; margin-left: 10px; margin-right: 10px; padding: 0px; cursor: pointer; border-style: solid;']";

            LocatingElements.LocatingElementsByariaLabel(Driver, "'Create new group'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact3Name"));
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").Clear();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys("Suraksha Sharma");
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Done'", "button").Click();

        }


        public void AddingContact(IWebDriver Driver, String Contact)
        {
            

            String SelectContacttoAdd = "//button[@role='button' and @tabindex='-1' and @style='position: relative; display: flex; flex-direction: column; flex-grow: 1; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: center; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; margin-left: 10px; margin-right: 10px; padding: 0px; cursor: pointer; border-style: solid;']";

            LocatingElements.LocatingElementsByariaLabel(Driver, "'Add to Group'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact7Name"));
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Done'", "button").Click();
            String Text = ConfigurationManager.AppSettings.Get("Contact7Name") + "Addded, number of participants: 6 ";
            SkypeBasicFeatures.SendingCustomMessage(Driver, Text);

        }

        public String SendingTheJoinLink(IWebDriver Driver)
        {
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Add to Group'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Share link to join group'", "button").Click();
            string JoinlinkCheckbox = "//button[@aria-label= 'Share group via link']";
            String Checkbox = LocatingElements.LocatingElementsByarialabel(Driver, JoinlinkCheckbox).GetAttribute("aria-checked");

            if (Checkbox == "false")
            {
                LocatingElements.LocatingElementsByarialabel(Driver, JoinlinkCheckbox).Click();
                Thread.Sleep(2000);
                String clipboard = "//button[@role='button' and @title='Copy to clipboard']";
                String JoinLink = LocatingElements.LocatingElementsByarialabel(Driver, clipboard).GetAttribute("aria-label");
                return JoinLink;
            }
            else
            {
                String clipboard = "//button[@role='button' and @title='Copy to clipboard']";
                String JoinLink = LocatingElements.LocatingElementsByarialabel(Driver, clipboard).GetAttribute("aria-label");
                return JoinLink;
            }

        }


        public void RemovingContact(IWebDriver Driver, String Contact)
        {
            String ParticipantsList = "//button[@role= 'button' and @tabindex= '-1'and @style='position: relative; display: flex; flex-direction: row; flex-grow: 0; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: flex-start; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; height: 25px; padding: 0px; cursor: pointer; border-style: solid;']";
            LocatingElements.LocatingElementsByarialabel(Driver, ParticipantsList).Click();
            //Instantiate Action Class        
            Actions actions = new Actions(Driver);
            //Retrieve WebElement 'Contact' to perform mouse hover 
            String Contact1 = "\'" + Contact + "\'";
            Console.Write(Contact1);

            IWebElement ContactOption = LocatingElements.LocatingElementsByariaLabel(Driver, Contact1, "div");
            //Mouse hover menuOption 'Music'
            actions.MoveToElement(ContactOption).Perform();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Remove user from conversation'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Remove'", "button").Click();

        }


        public void JoiningAGroup(IWebDriver Driver1, IWebDriver Driver2, IWebDriver Driver3, IWebDriver Driver4)
        {
            String JoinLink = SendingTheJoinLink(Driver1);
            miscellaneous.SelectingContact(Driver1, ConfigurationManager.AppSettings.Get("Contact3Name"), "P2P");
            SkypeBasicFeatures.SendingCustomMessage(Driver1, JoinLink);
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(Driver1, Driver2, Driver3, Driver4, 3);
            miscellaneous.ClickOnLatestRecievedMessage(Driver3);
            String Joining = "//button[@role='button' and @tabindex='-1' and @style='position: relative; display: flex; flex-direction: column; flex-grow: 0; flex-shrink: 0; overflow: hidden; align-items: stretch; justify-content: center; background-color: rgb(241, 241, 244); border-color: rgba(0, 0, 0, 0); text-align: left; border-width: 0px; width: 300px; border-radius: 10px 10px 0px; padding: 0px; cursor: pointer;']";
            LocatingElements.LocatingElementsByarialabel(Driver3, Joining).Click();

        }


        public void CreatingGroupThruCons(IWebDriver Driver, String GroupType)
        {
            String SelectContacttoAdd = "//button[@role='button' and @tabindex='-1' and @style='position: relative; display: flex; flex-direction: column; flex-grow: 1; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: center; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; margin-left: 10px; margin-right: 10px; padding: 0px; cursor: pointer; border-style: solid;']";
            String GroupName;
            LocatingElements.LocatingElementsByariaLabel(Driver, "'New Chat'", "button").Click();
            if (GroupType == "Grpthrucons")
            {
                LocatingElements.LocatingElementsByariaLabel(Driver, "'New Group Chat'", "button").Click();
                GroupName = " GrpthruConsUsingAutoScript";
            }
            else
            {
                LocatingElements.LocatingElementsByariaLabel(Driver, "'New Moderated Group'", "button").Click();
                GroupName = " ModeratedGrpUsingAutoScript";
            }

            DateTime date = DateTime.Now;
            String datetoday = date.ToString();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Group Name: '", "input").SendKeys(datetoday + GroupName);
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Next'", "button").Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact2Name"));
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").Clear();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact6Name"));
            Thread.Sleep(3000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").Clear();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact5Name"));
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").Clear();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Search'", "input").SendKeys(ConfigurationManager.AppSettings.Get("Contact4Name"));
            Thread.Sleep(2000);
            LocatingElements.LocatingElementsByarialabel(Driver, SelectContacttoAdd).Click();
            LocatingElements.LocatingElementsByariaLabel(Driver, "'Done'", "button").Click();

        }

        public void ReamingTheGroup(IWebDriver Driver)
        {
            String ClickOnTheGroupName = "//button[@role= 'button' and @style='position: relative; display: flex; flex-direction: row; flex-grow: 0; flex-shrink: 0; overflow: hidden; align-items: stretch; justify-content: flex-start; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; padding: 0px; cursor: pointer; border-style: solid;']";
            LocatingElements.LocatingElementsByarialabel(Driver, ClickOnTheGroupName).Click();
            String EditTitle = "//div[@role = 'none' and@style = 'position: relative; display: flex; flex - direction: row; flex - grow: 1; flex - shrink: 1; overflow: hidden; align - items: center; align - self: stretch; justify - content: center; padding - bottom: 1px; border - width: 0px 0px 1px; border - style: solid; border - color: rgba(0, 0, 0, 0); opacity: 0.7; ']";
            LocatingElements.LocatingElementsByarialabel(Driver, EditTitle).Click();
            
        }



        public void LeaveGroup(IWebDriver Driver, String Contact)
        {
            String ParticipantsList = "//button[@role= 'button' and @tabindex= '-1'and @style='position: relative; display: flex; flex-direction: row; flex-grow: 0; flex-shrink: 1; overflow: hidden; align-items: stretch; justify-content: flex-start; background-color: transparent; border-color: transparent; text-align: left; border-width: 0px; height: 25px; padding: 0px; cursor: pointer; border-style: solid;']";
            miscellaneous.ClickOnLatestRecievedMessage(Driver);
            LocatingElements.LocatingElementsByarialabel(Driver, ParticipantsList).Click();
            LocatingElements.LocatingElementsByarialabel(Driver, "'Leave group'").Click();
            LocatingElements.LocatingElementsByarialabel(Driver, "'Leave group'").Click();

        }

        public void GroupFunctionalities(IWebDriver d1, IWebDriver d2, IWebDriver d3, IWebDriver d4,String GroupType)
        {
            
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            miscellaneous.ClickOnLatestRecievedMessage(d2);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            miscellaneous.ClickOnLatestRecievedMessage(d1);
            Thread.Sleep(2000);
            String GroupMessage;
            if (GroupType == "Grpthrucons")
            {
                GroupMessage = "Group Thru Contacts ";
            }
            else if(GroupType == "Modgrp")
            {
                GroupMessage = "Moderated Group ";
            }
            else if (GroupType == "nonamegrp")
            {
                GroupMessage = "Group Thru Chat Without Name ";
            }
            else
            {
                GroupMessage = "Group Thru Chat With Name ";
            }

            SkypeBasicFeatures.SendingStartOfTestMessage(d1, GroupMessage, ConfigurationManager.AppSettings.Get("Contact1Name"));
            SkypeBasicFeatures.SendingTextMessages(d1, GroupMessage, ConfigurationManager.AppSettings.Get("Contact1Name"));
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.SendingTextMessages(d2, GroupMessage, ConfigurationManager.AppSettings.Get("Contact2Name"));
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

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.UploadingFiles(d2);
            Thread.Sleep(2000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            SkypeBasicFeatures.MakeCall(d1);
            Thread.Sleep(10000);
            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 2);
            SkypeBasicFeatures.ReceavingCall(d2, ConfigurationManager.AppSettings.Get("Contact1Name"));
            Thread.Sleep(20000);
            SkypeBasicFeatures.EndCall(d2);

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            AddingContact(d1, ConfigurationManager.AppSettings.Get("Contact7Name"));
            Thread.Sleep(5000);

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            JoiningAGroup(d1, d2, d3, d4);
            Thread.Sleep(5000);

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 1);
            RemovingContact(d1, ConfigurationManager.AppSettings.Get("Contact5Name"));
            Thread.Sleep(5000);

            miscellaneous.BringBrowserinFocus(d1, d2, d3, d4, 4);
            LeaveGroup(d4, ConfigurationManager.AppSettings.Get("Contact4Name"));
            Thread.Sleep(5000);

        }



    }
}
