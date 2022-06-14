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
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        { 
            ProjectData project = new ProjectData()
            {
                Name = GenerateRandomString(10),
                Description = GenerateRandomString(100)
            };
            app.Menu.MenuProjects();
            List<ProjectData> oldList = app.Project.GetProjectList();
            app.Project.CreateProject(project);
            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}