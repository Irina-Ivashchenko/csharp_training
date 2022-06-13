using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            if (app.Groups.GetGroupList().Count == 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "TestNameForRemov"
                };

                app.Groups.Add(newGroup);
            }
            
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            int id = oldGroups.Count() - 1;
            GroupData toBeRemoved = oldGroups[id];
            app.Groups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupList().Count());
            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Remove(toBeRemoved);
            Assert.AreEqual(oldGroups.Count, newGroups.Count);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
