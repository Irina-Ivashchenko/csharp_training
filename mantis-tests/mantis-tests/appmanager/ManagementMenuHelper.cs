using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ManagementMenuHelper : HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void MenuProjects()
        {
            OpenManagePage();
            GoToProjectsPage();
        }

        public void OpenManagePage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_overview_page.php']")).Click();
        }

        public void GoToProjectsPage()
        {
            driver.FindElement(By.XPath("//a[@href='/mantisbt-2.25.4/manage_proj_page.php']")).Click();
        }
    }
}