using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearch()
        {
            int SearchResult = app.Contacts.GetNumberOfSearchResults();
            int ContactCount = app.Contacts.GetContactCount();

            Assert.AreEqual(SearchResult, ContactCount);
        }
    }
}
