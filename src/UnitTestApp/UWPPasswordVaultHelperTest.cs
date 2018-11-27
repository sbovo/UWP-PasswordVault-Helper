
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWP_PasswordVault_Helper;
using Windows.Security.Credentials;

namespace UnitTestApp
{
    [TestClass]
    public class UWPPasswordVaultHelperTest
    {
        [TestMethod]
        public void GetPasswordCredential_EmptyResource_shouldReturnNull()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            PasswordCredential pc = pvh.GetPasswordCredential(null, "SampleUserName");
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void GetPasswordCredential_EmptyUsername_shouldReturnNull()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            PasswordCredential pc = pvh.GetPasswordCredential("SampleResource", null);
            Assert.IsNull(pc);
        }

        [TestMethod]
        public void WritePasswordCredential_EmptyPassword_shouldReturnNull()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            bool result = pvh.WritePasswordCredential("SampleResource", "ABC", null);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void WritePasswordCredential_shouldReturnTrue()
        {
            PasswordVaultHelper pvh = new PasswordVaultHelper();
            bool result = pvh.WritePasswordCredential("SampleResource", "1234", "secrect");
            Assert.IsTrue(result);
        }
    }
}
