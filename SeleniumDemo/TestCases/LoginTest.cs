using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;
using SeleniumDemo.PageObjects;
using System.Configuration;

namespace SeleniumDemo.TestCases
{
	class LoginTest
	{
		IWebDriver driver = new FirefoxDriver();
		[Test]
		public void Test()
		{
			//IWebDriver driver = new FirefoxDriver();
			driver.Manage().Window.Maximize();
			driver.Url = "http://www.store.demoqa.com";
			driver.FindElement(By.XPath(".//*[@id='account']/a")).Click();

			waitforelement(By.Id("account2"), 10);
			// Find the element that's ID attribute is 'log' (Username)
			// Enter Username on the element found by above desc.
			Thread.Sleep(3000);
			driver.FindElement(By.Id("log")).SendKeys("testuser_1");

			// Find the element that's ID attribute is 'pwd' (Password)
			// Enter Password on the element found by the above desc.
			driver.FindElement(By.Id("pwd")).SendKeys("Test@123");

			// Now submit the form.
			driver.FindElement(By.Id("login")).Click();
			
			// Find the element that's ID attribute is 'account_logout' (Log Out)
			driver.FindElement(By.XPath(".//*[@id='account_logout']/a")).Click();

			driver.Quit();
		}

		[Test]
		public void TestPageFactory()
		{
			IWebDriver driver = new FirefoxDriver();
			driver.Manage().Window.Maximize();
			//driver.Url = "http://www.store.demoqa.com";
			driver.Url = ConfigurationManager.AppSettings["URL"];

			HomePage home = new HomePage(driver);
			//PageFactory.InitElements(driver, home);

			//waitforelement(By.Id("account"), 10);
			home.MyAccount.Click();

						var loginPage = new LoginPage();
			PageFactory.InitElements(driver, loginPage);
			Thread.Sleep(2000);
			loginPage.LoginToApplication();


			//loginPage.UserName.SendKeys("TestUser_1");
			//loginPage.Password.SendKeys("Test@123");
			//loginPage.Submit.Submit();

			Thread.Sleep(3000);

			loginPage.Submit.Submit();
		}


		public void waitforelement(By descriptor, int  time)
		{
			WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(time));
			wait.Until(ExpectedConditions.ElementIsVisible(descriptor));
		}
	}
}
