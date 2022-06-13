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
    public class AccountCreationTests: TestBase
    {

        [TestFixtureSetUp]

        public void SetUpConfig()
        {
            app.Ftp.BackUpFile("/config/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))

            {
                app.Ftp.Upload("/config/config_inc.php", localFile);
            }

        }

        [Test]
        public void TestAccountRegistration()
        {
            AccountData account = new AccountData()
            {
                Name = "Testuser",
                Password = "password",
                Email = "testuser@localhost.localdomain"
            };
            
            app.Registration.Register(account);
        }

        [TestFixtureTearDown]

        public void RestoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config/config_inc.php"); 
        }
    }
}
