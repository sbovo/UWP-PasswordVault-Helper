
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWP_PasswordVault_Helper;
using Windows.Security.Credentials;

namespace UnitTestApp
{
    [TestClass]
    public class UWPPasswordVaultHelperTest_GET
    {
        [TestMethod]
        public void EmptyResource_shouldReturnNull()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            PasswordCredential pc = pvh.GetPasswordCredential(null, "SampleUserName");
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void EmptyUsername_shouldReturnNull()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            PasswordCredential pc = pvh.GetPasswordCredential("SampleResource", null);
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void Username_shouldPasswordCredential()
        {
            string resource = "SampleResourceForGet";
            string username = "UserID";
            string password = "secret";
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            bool result = pvh.WritePasswordCredential(resource, username, password);

            PasswordVaultHelper pvhget = new PasswordVaultHelper();
            PasswordCredential pc = pvhget.GetPasswordCredential(resource,username);
            bool success = pc.Password.CompareTo(password) == 0;
            Assert.IsTrue(success);
        }

        
    }
}
