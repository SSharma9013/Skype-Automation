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


using OpenQA.Selenium.Remote;
using System.IO;
using System.Diagnostics;

using System.Configuration;
using System.Collections.Specialized;

namespace SkypeAutomation
{
    //This class is used to locate elements 
    public class LocatingElements
    {

        


        //Function to locate elements which have name as an attribute
        public IWebElement LocatingElementsByName(IWebDriver Driver, String NameString)
        {
            IWebElement Element = Driver.FindElement(By.Name(NameString));
            return Element;

        }

        //Function to locate elements which have Id as an attribute
        public IWebElement LocatingElementsById(IWebDriver Driver, String IdString)
        {
            IWebElement Element = Driver.FindElement(By.Id(IdString));
            return Element;
        }

        //Function to locate elements which have aria label and element type as an attribute
        public IWebElement LocatingElementsByariaLabel(IWebDriver Driver, String AriaLabel, String ElementType)
        {
            IWebElement Element = Driver.FindElement(By.XPath("//" + ElementType + "[@aria-label=" + AriaLabel + "]"));
            return Element;
        }
        //Function to locate elements which have placeholder as an attribute
        public IWebElement LocatingElementsByPlaceholder(IWebDriver Driver, String PlaceholderLabel, String ElementType)
        {
            IWebElement Element = Driver.FindElement(By.XPath("//" + ElementType + "[@placeholder=" + PlaceholderLabel + "]"));
            return Element;
        }
        //Function to locate elements which have complete xpath as an attribute
        public IWebElement LocatingElementsByarialabel(IWebDriver Driver, String XpathString)
        {
            IWebElement Element = Driver.FindElement(By.XPath(XpathString));
            return Element;
        }




    }

  
    

}