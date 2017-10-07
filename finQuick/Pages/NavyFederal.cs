using finQuick.Utilities;
using OpenQA.Selenium;
using Yarr = finQuick.Secrets.HereBeDragons;

namespace finQuick.Pages
{
    class NavyFederal
    {
        private static IWebElement UsernameInput => Driver.Instance.FindElement(By.Id("user"));

        private static IWebElement PasswordInput => Driver.Instance.FindElement(By.Id("password"));

        private static IWebElement loginButton => Driver.Instance.FindElement(By.Name("signin"));




        public static void Login()
        {
            UsernameInput.SendKeys(Yarr.NavyFederal[0]);
            PasswordInput.SendKeys(Yarr.NavyFederal[1]);
        }
    }
}
