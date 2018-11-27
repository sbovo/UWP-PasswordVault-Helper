using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace UWP_PasswordVault_Helper
{
    public interface IPasswordVaultHelper
    {
        PasswordCredential GetPasswordCredential(string resource, string userName,
            Action<string> error);
        bool WritePasswordCredential(string resource, string userName, string password, 
            Action<string> error);
        bool DeletePasswordCredential(string resource, string userName,
            Action<string> error);
    }
}
