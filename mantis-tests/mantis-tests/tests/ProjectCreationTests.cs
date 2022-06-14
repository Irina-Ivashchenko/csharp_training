using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;

namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : TestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountData account = new AccountData()
            {
                Name = "administrator",
                Password = "root"
            }; 
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(10),
                Description = GenerateRandomString(100)
            };
            app.LogIn.Login(account);
            app.Menu.MenuProjects();
            List<ProjectData> oldList = app.API.GetProjectList(account);
            app.Project.CreateProject(project);
            List<ProjectData> newList = app.API.GetProjectList(account);
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}