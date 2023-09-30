using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Remote;

namespace NUnit.Test.Web
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static IWebDriver driver = new ChromeDriver();
        private static readonly string testUrl = "https://www.google.com";
        [SetUp]
        public void NUnit_Test_Calculate()
        {
            ChromeOptions capabilities = new ChromeOptions();
            capabilities.BrowserVersion = "117.0.5938.132";

        }

        [Test]
        public void Text_Chrome_Open_Close()
        {
            driver.Navigate().GoToUrl(testUrl);

            //assert title
            Assert.That(driver.Title.Equals("Google"));

            driver.Close();
        }

        [Test]
        public void Test_Chrome_Refresh()
        {
            driver.Navigate().GoToUrl(testUrl);

            //assert title
            Assert.That(driver.Title.Equals("Google"));

            driver.Navigate().Refresh();

            driver.Close();
        }

        [Test]
        public void Test_Chrome_WindowMaximize()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            driver.Manage().Window.Maximize();

            Assert.That(WindowState == FormWindowState.Maximized, Is.False);

            driver.Close();
        }

        [Test]
        public void Test_Chrome_WindowMinimize()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            driver.Manage().Window.Minimize();

            Assert.That(WindowState == FormWindowState.Minimized, Is.False);
            driver.Close();
        }

        [Test]
        public void Test_Chrome_ChangeSize()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            driver.Manage().Window.Size = new Size(600, 400);

            Assert.That(driver.Manage().Window.Size.Width,Is.EqualTo(600));
            Assert.That(driver.Manage().Window.Size.Height, Is.EqualTo(400));
            driver.Close();
        }

        [Test]
        public void Test_Chrome_WriteText()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);

            //act
            IWebElement searchBox = driver.FindElement(By.Name("q"));
            searchBox.SendKeys("Selenium WebDriver");
            driver.Close();
        }

        [Test]
        public void Test_Chrome_Back()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            driver.Navigate().GoToUrl(@"https://www.mail.ru");
            driver.Navigate().Back();
            //assert
            Assert.That(driver.Title.Equals("Google"));
            driver.Close();
        }

        [Test]
        public void Test_Chrome_Forward()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            driver.Navigate().GoToUrl(@"https://www.mail.ru");
            driver.Navigate().Back();
            driver.Navigate().Forward();
            //assert
            Assert.That(driver.Url.Equals(@"https://mail.ru/"));
            driver.Close();
        }

        [Test]
        public void Test_Chrome_Cookies()
        {
            //Arrange
            driver.Navigate().GoToUrl(testUrl);
            //act
            var cookie = driver.Manage().Cookies.GetCookieNamed("currency");
            driver.Close();

        }
       
        private void button4_Click(object sender, EventArgs e)
        {

            
        }
    }
}
