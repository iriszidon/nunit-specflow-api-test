using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Linq;

namespace NunitTest
{
    public class NunitTest
    {
        public ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            this.driver = new ChromeDriver("C:\\Optimove\\NunitTest\\NunitTest\\ChromeDriver");
            driver.Navigate().GoToUrl("https://www.90min.com/");
        }
        [TearDown]
        public void TearDown()
        {
            this.driver.Close();
            this.driver.Dispose();
            this.driver.Quit();
        }

        [Test]
        public void BrowseToYnetWebsite()
        {           
            var container = driver.FindElement(By.Id("mm-root"));
            var navBar = container.FindElement(By.TagName("nav"));
            var linksList = navBar.FindElements(By.XPath("//div//ul//li//span")).Select(x => x.Text);
            Assert.True(linksList.Contains("Gaming"), $"Found Item with text: {linksList.First()}");
            Assert.True(linksList.Contains("Transfers"), $"Found Item with text: {linksList.ElementAt(1)}");
            Assert.True(linksList.Contains("Premier League"), $"Found Item with text: {linksList.ElementAt(2)}");
            Assert.True(linksList.Contains("European Leagues"), $"Found Item with text: {linksList.ElementAt(3)}");
            Assert.True(linksList.Contains("Players"), $"Found Item with text: {linksList.ElementAt(4)}");
            Assert.True(linksList.Contains("Champions League"), $"Found Item with text: {linksList.ElementAt(5)}");
            Assert.True(linksList.Contains("World Cup"), $"Found Item with text: {linksList.ElementAt(6)}");
        }
    }
}