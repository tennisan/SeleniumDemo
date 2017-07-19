using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumDemo.PageObjects
{
	public class HomePage
	{
		public HomePage(IWebDriver driver)
		{
			this.driver = driver;
			PageFactory.InitElements(driver, this);
		}
		private IWebDriver driver;

		[FindsBy(How = How.Id, Using = "account")] 
		public IWebElement MyAccount { get; set; }

		
	}
}
