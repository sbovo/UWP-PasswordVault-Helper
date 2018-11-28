
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UWP_PasswordVault_Helper;
using Windows.Security.Credentials;

namespace UnitTestApp
{
    [TestClass]
    public class UWPPasswordVaultHelperTest_WRITE
    {
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
            bool result = pvh.WritePasswordCredential("SampleResource", "1234", "secret");
            Assert.IsTrue(result);
        }
    }
}
