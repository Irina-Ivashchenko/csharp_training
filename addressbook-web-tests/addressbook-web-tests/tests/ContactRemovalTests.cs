using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.OpenHomePage();
            if (!app.Contacts.IsContactCreate())
            {
                ContactData contact = new ContactData("NewFirstname", "NewLastname");
                app.Contacts.Create(contact);
            }
                app.Contacts.Remove(1);
        }

    }
}
