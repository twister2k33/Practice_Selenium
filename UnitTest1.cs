using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Selenium_Practice
{


    public class EntryPoint
    {

        public IWebDriver driver;

        [SetUp]

        public void Initialize()
        {

            driver = new ChromeDriver();


        }




        [Test]

        public void Test1()
        {

            driver.Navigate().GoToUrl("http://duckduckgo.com");

            Thread.Sleep(3000);

            IWebElement textSearch = driver.FindElement(By.Id("search_form_input_homepage"));
            IWebElement submit = driver.FindElement(By.Id("search_button_homepage"));

            textSearch.SendKeys("Seinfeld of course");
            submit.Click();

            



        }





        [TearDown]

        public void EndTest()
        {

            driver.Quit();
        }





    }



    }

