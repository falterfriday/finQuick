using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace finQuick.Utilities
{
    public static class DriverExtensions
    {
        /// <summary>
        /// Browser will scroll to the selected element
        /// </summary>
        /// <param name="element"></param>
        internal static IWebElement ScrollToElement(this IWebDriver driver, IWebElement element)
        {
            return (IWebElement)((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        /// <summary>
        /// Browser will wait for designated time in seconds before continuing
        /// </summary>
        /// <param name="seconds"></param>
        internal static void Wait(this IWebDriver driver, int seconds)
        {
            Thread.Sleep(seconds * 1000);
        }

        /// <summary>
        /// Browser will wait for designated time in seconds before continuing
        /// </summary>
        /// <param name="seconds"></param>
        internal static void Wait(this IWebDriver driver, double seconds)
        {
            Thread.Sleep(Convert.ToInt32(seconds * 1000));
        }

        /// <summary>
        /// Move the cursor to the designated element
        /// </summary>
        /// <param name="element"></param>
        internal static void MoveMouseTo(this IWebDriver driver, IWebElement element)
        {
            var builder = new Actions(driver);
            builder.MoveToElement(element).Build().Perform();
        }

        /// <summary>
        /// Driver will wait 30 seconds for the element to be clickable
        /// </summary>
        /// <param name="element"></param>
        internal static IWebElement WaitUntilClickable(this IWebDriver driver, IWebElement element, ExpectedCondition condition = ExpectedCondition.Clickable, int waitTime = 30)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException), typeof(NoSuchElementException));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

            return element;
        }

        /// <summary>
        /// Driver will wait 30 seconds for the element to be visible
        /// </summary>
        /// <param name="by"></param>
        internal static IWebElement WaitUntilVisible(this IWebDriver driver, By by, ExpectedCondition condition = ExpectedCondition.Visible, int waitTime = 15)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(waitTime));
            wait.IgnoreExceptionTypes(typeof(WebDriverTimeoutException), typeof(NoSuchElementException));

            switch (condition)
            {
                case ExpectedCondition.Visible:
                    {
                        wait.Until(ExpectedConditions.ElementIsVisible(by));
                        break;
                    }
                case ExpectedCondition.SwitchToFrame:
                    {
                        wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
                        break;
                    }
            }

            return driver.FindElement(by);
        }

        internal enum ExpectedCondition
        {
            Clickable,
            Visible,
            SwitchToFrame
        }
    }
}
