using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests: AuthTestBase
    {
           
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Ivan", "Ivanov");
            /* Here you can enter values ​​for optional parameters ContactData
            contact.Nickname = "Vano";
            contact.Notes = "colleague"; */
            app.Contacts.Create(contact);

            //app.Auth.Logout();
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("", "");
            app.Contacts.Create(contact);

            //app.Auth.Logout();
        }

    }
}
