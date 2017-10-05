using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;
using System;
using System.IO;

namespace finQuick
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string DriverPath { get; set; }

        public static void Initialize()
        {
            Instance = new ChromeDriver();
            Instance.Manage().Window.Maximize();
        }

        public static void Initialize(string BrowserSelection)
        {
            if (DriverPath == null)
            {
                GetDriverPath();
            }

            switch (BrowserSelection.Trim().ToUpper())
            {
                case "CHROME":
                    Instance = new ChromeDriver(DriverPath);
                    Instance.Manage().Window.Maximize();
                    break;
                default:
                    Instance = new ChromeDriver(DriverPath);
                    break;
            }
        }

        public static void TearDown()
        {
            Instance.Close();
            Instance.Quit();
        }

        public static void GoTo(string inURL)
        {
            Instance.Url = inURL;
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void GetDriverPath()
        {
            string filePath =
                Path.Combine(
                    Path.GetFullPath(
                        Path.Combine(
                            AppDomain.CurrentDomain.BaseDirectory +
                                @"\..\..\..\SimsAutomatedTestFramework\DriverSupport")));
            DriverPath = filePath;
        }
    }
}