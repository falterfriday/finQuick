using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace finQuick.Pages
{
    static class BankOfAmericaLogin
    {
        private static IWebElement LoginUsernameInput => Driver.Instance.FindElement(By.Id("onlineId1"));
        private static IWebElement LoginPasswordInput => Driver.Instance.FindElement(By.Id("passcode1"));
        private static IWebElement LoginButton => Driver.Instance.FindElement(By.Id("hp-sign-in-btn"));

        private static ReadOnlyCollection<IWebElement> CardBalances => Driver.Instance.FindElements(By.ClassName("balanceValue"));

        private static IWebElement LogOutLink => Driver.Instance.FindElement(By.LinkText("Sign Out"));

        public static ReadOnlyCollection<IWebElement> Login()
        {
            LoginUsernameInput.SendKeys(Secrets.BankOfAmerica[0]);
            LoginPasswordInput.SendKeys(Secrets.BankOfAmerica[1]);
            LoginButton.Click();
            Driver.Instance.Wait(2);
            return CardBalances;
        }
        public static void LogOut()
        {
            LogOutLink.Click();
            Driver.Instance.Wait(1);
        }
    }
}
