using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public void CreateProject(ProjectData project)
        {
            InitCteateProject();
            FillProjectForm(project);
            SubmitCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.XPath("(//table/tbody)[1]/tr")).Count > 0);
        }

        public void DeleteProject(int id)
        {
            OpenProject(id);
            SubmitRemoveProject();
            AcceptRemoveProject();
        }

        public void InitCteateProject()
        {
            driver.FindElement(By.XPath("//form[@action=\"manage_proj_create_page.php\"]//button[@type=\"submit\"]")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Name("name")).SendKeys(project.Name);
            driver.FindElement(By.Name("description")).SendKeys(project.Description);
        }

        public void SubmitCreation()
        {
            driver.FindElement(By.XPath("//input[@type=\"submit\"]")).Click();
        }

        public List<ProjectData> GetProjectList()
        {
            List<ProjectData> projectList = new List<ProjectData>();

            ICollection<IWebElement> elements = driver.FindElements(By.XPath("(//table/tbody)[1]/tr"));
            foreach (IWebElement element in elements)
            {
                projectList.Add(new ProjectData()
                {
                    Id = Regex.Match(element.FindElement(By.XPath("./td[1]/a")).GetAttribute("href"), "\\d+").Value,
                    Name = element.FindElement(By.XPath("./td[1]")).Text,
                    Description = element.FindElement(By.XPath("./td[5]")).Text
                });
            }
            return projectList;
        }
        public void ProjectExistanceCheck()
        {
            if (driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("a")).Count() == 0)
            {
                ProjectData project = new ProjectData()
                {
                    Name = "TestProjectName",
                    Description = "TestDescription"
                };
                CreateProject(project);
                manager.Driver.Url = "http://localhost/mantisbt-2.25.4/manage_proj_page.php";
            };
        }

        public void OpenProject(int id)
        {
            driver.FindElement(By.TagName("tbody")).FindElements(By.TagName("a"))[id].Click();
        }

        public void SubmitRemoveProject()
        {
            driver.FindElement(By.CssSelector("form#project-delete-form input[type=\"submit\"]")).Click();
        }

        public void AcceptRemoveProject()
        {
            driver.FindElement(By.CssSelector("form.center input[type=\"submit\"]")).Click();
        }


    }
}