using finQuick.Utilities;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using Yarr = finQuick.Secrets.HereBeDragons;

namespace finQuick.Pages
{
    public static class BankOfAmerica
    {
        private static IWebElement LoginUsernameInput => Driver.Instance.FindElement(By.Id("onlineId1"));

        private static IWebElement LoginPasswordInput => Driver.Instance.FindElement(By.Id("passcode1"));

        private static IWebElement LoginButton => Driver.Instance.FindElement(By.Id("hp-sign-in-btn"));

        private static ReadOnlyCollection<IWebElement> CardBalances => Driver.Instance.FindElements(By.ClassName("balanceValue"));

        private static IWebElement LogOutLink => Driver.Instance.FindElement(By.LinkText("Sign Out"));

        public static void Login()
        {
            LoginUsernameInput.SendKeys(Yarr.BankOfAmerica[0]);
            Driver.Instance.Wait(0.5);
            LoginPasswordInput.SendKeys(Yarr.BankOfAmerica[1]);
            LoginButton.Click();
            Driver.Instance.Wait(2);
        }

        public static ReadOnlyCollection<IWebElement> MainPageInfo()
        {
            return CardBalances;
        }

        public static void LogOut()
        {
            LogOutLink.Click();
            Driver.Instance.Wait(1);
        }
    }
}
