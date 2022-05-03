using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {

    [Test]
    public void GroupRemovalTest()
        {
            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupCreate())
            {
                GroupData group = new GroupData("newData");
                group.Header = "newHeader";
                group.Footer = "newFooter";

                app.Groups.Create(group);
            }
            app.Groups.Remove(1);
        }

    }
}
