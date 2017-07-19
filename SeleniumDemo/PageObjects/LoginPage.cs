﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;


namespace SeleniumDemo.PageObjects
{
	public class LoginPage
	{
		private IWebDriver driver;

		[FindsBy(How = How.Id, Using = "log")]
		public IWebElement UserName { get; set; }

		[FindsBy(How = How.Id, Using = "pwd")]
		public IWebElement Password { get; set; }

		[FindsBy(How = How.Id, Using = "login")] 
		public IWebElement Submit { get; set; }

		public void LoginToApplication()
		{
			UserName.SendKeys("uname");
			Password.SendKeys("password");
			Submit.Submit();
		}
	}
}
