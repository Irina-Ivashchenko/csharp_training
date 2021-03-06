using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
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

              List<ContactData> oldContacts = ContactData.GetAll();
              ContactData toBeRemoved = oldContacts[0];
              app.Contacts.Remove(toBeRemoved);
              Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

              List<ContactData> newContacts = ContactData.GetAll();

              oldContacts.RemoveAt(0);
              oldContacts.Sort();
              newContacts.Sort();
              Assert.AreEqual(oldContacts, newContacts); 

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

    }
}
