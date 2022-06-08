using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemovingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestRemovingContactFromGroup()
        {
            app.Groups.GroupExistenceCheck();
            app.Contacts.ContactExistanceCheck(); 
            GroupData group = GroupData.GetAll()[0];
            app.Contacts.ContactInGroupCheck(group);
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = oldList[0];
            app.Contacts.RemoveContactFromGroup(contact, group);
            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
