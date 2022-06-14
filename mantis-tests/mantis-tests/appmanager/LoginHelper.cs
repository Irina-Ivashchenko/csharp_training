using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager) { }

        public void Login(AccountData account)
        {
            OpenMainPage();
            FillLoginForm(account);     
        }

        public void OpenMainPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.4/login_page.php";
        }

        public void FillLoginForm(AccountData account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            Login();
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            Login();
        }

        public void Login()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }
    }
}