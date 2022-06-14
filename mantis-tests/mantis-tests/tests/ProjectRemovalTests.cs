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
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()
        { 
            app.Menu.MenuProjects();
            app.Project.ProjectExistanceCheck();
            List<ProjectData> oldList = app.Project.GetProjectList();
            app.Project.DeleteProject(0);
            List<ProjectData> newList = app.Project.GetProjectList();
            oldList.RemoveAt(0);
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);
        }
    }
}