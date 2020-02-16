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


        //the tags [setup] [Test] and [TearDown] are part of nunit. You add nunit the same way you add selentium to your project. RC the project > manage nget packages
        // and install. The project should already have everything you need. Selenium, Selenium chrome driver and nunit.
        // in setup I usually just initialize the driver..in this case, the chrome driver...but you'd initialize firefox driver and iedriver the same way you just have to 
        //install them like you would chromedriver (see above)
        [SetUp]

        public void Initialize()
        {

            driver = new ChromeDriver();


        }


        //[Test] is where the tests execute. Each test would run under a seperate [test] tag...The function defined under [test] will always run. If you try to put two 
        //functions under one [test] tag only  the first function will run. You'd need to add a 2nd [test] for the 2nd function to run. I create a simple example below of
        //two tests

        [Test]


        public void Test1()
        {

            // driver is what was defined in setup. This is what you use to drive the tests. Right here I'm simply opening chrome and navigating to the url
            driver.Navigate().GoToUrl("http://duckduckgo.com");

            //here I'm just telling the browser to wait 3 seconds to give the page time to load. There are more complex functions for this  you can learn later
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);


            //here I"m defining the elements I want to interact with on the page. The first is the search box and 2nd is the magnifying class button to execute the search
            IWebElement textSearch = driver.FindElement(By.Id("search_form_input_homepage"));
            IWebElement submit = driver.FindElement(By.Id("search_button_homepage"));

            //pretty obvious...telling driver to input the text in the textSearch variable I defined above
                                  
            
            textSearch.SendKeys("Seinfeld of course");
            
            //this needs no explanation
            submit.Click();

        }

        [Test]

        public void Test2()
        {

            //first part is same as above but a different url
            driver.Navigate().GoToUrl("http://duckduckgo.com");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            IWebElement textSearch = driver.FindElement(By.Id("search_form_input_homepage"));
            IWebElement submit = driver.FindElement(By.Id("search_button_homepage"));

            textSearch.SendKeys("Texas Sports");
            submit.Click();


            //I want to open the first link that's returned. This is the xpath for the first link that appears on the page
            IWebElement firstLink = driver.FindElement(By.XPath("//div[@id='r1-0']//div//h2//a"));
            
           //this should open the first link
            firstLink.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);


        }


        //Teardown is what runs after each [test] above. you'll notice that before it runs the 2nd [test] it closes the browser. That's because I'm telling the driver
        // to quit here
        [TearDown]

        public void EndTest()
        {

            driver.Quit();
        }





    }



    }

