using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class ContactInformationTests: AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData FromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData FromForm = app.Contacts.GetContactInformationFromEditForm(0);

            Assert.AreEqual(FromTable, FromForm);
            Assert.AreEqual(FromTable.Address, FromForm.Address);
            Assert.AreEqual(FromTable.AllPhones, FromForm.AllPhones);
            Assert.AreEqual(FromTable.AllEmails, FromForm.AllEmails);
        }
    }
}
