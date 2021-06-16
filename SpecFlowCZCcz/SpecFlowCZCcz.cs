using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace SpecFlowCZCcz
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        IWebDriver driver;
        string testUrl = "https://www.czc.cz/";
        string product = "";
        

        
        [Given(@"that i am on the czc webpage")]
        public void GivenThatIAmOnTheCzcWebpage()
        {
            driver = new FirefoxDriver();
            driver.Url = testUrl;
            driver.Manage().Window.Maximize();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Then(@"find search box to enter (.*)")]
        public void ThenFindSearchBoxToEnterFindingProduct(string findingproduct)
        {
            IWebElement searchbox = driver.FindElement(By.Id("fulltext"));
            searchbox.SendKeys(findingproduct);
        }
        
        [Then(@"click search button")]
        public void ThenClickSearchButton()
        {
            IWebElement searchButton = driver.FindElement(By.XPath("/html/body/div[2]/header/div[2]/div/div/div[1]/form/button"));
            searchButton.Click();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Then(@"click first category")]
        public void ThenClickFirstCategory()
        {
            IWebElement firstCategory = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]/div[2]/div/div[3]/a[1]/h3"));
            firstCategory.Click();
            System.Threading.Thread.Sleep(2000);
        }
        
        [Then(@"add first product to cart")]
        public void ThenAddFirstProductToCart()
        {
            IWebElement addproduct = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]/div[2]/div/div[5]/div[1]/div[2]/div[1]/h5/a"));
            product = addproduct.Text;
            IWebElement addButton = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]/div[2]/div/div[5]/div[1]/div[2]/div[2]/button"));
            addButton.Click();
            System.Threading.Thread.Sleep(2000);
            
        }
        
        [Then(@"verify whether item is added to cart")]
        public void ThenVerifyWhetherItemIsAddedToCart()
        {
            IWebElement addedproduct = driver.FindElement(By.XPath("/html/body/div[2]/div[3]/div[1]/div[2]/div/div/div[1]/div[1]/a"));
            string verifyingproduct = addedproduct.Text;
            Assert.That((product.Contains(verifyingproduct)), Is.True);
        }
        
        [Then(@"close the browser instance")]
        public void ThenCloseTheBrowserInstance()
        {
            driver.Quit();
        }
    }
}
