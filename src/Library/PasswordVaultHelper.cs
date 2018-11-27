using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace UWP_PasswordVault_Helper
{
    public class PasswordVaultHelper : IPasswordVaultHelper
    {
        public PasswordCredential GetPasswordCredential(string resource, string userName,
            Action<string> error = null)
        {
            if (String.IsNullOrEmpty(resource)
                || String.IsNullOrEmpty(userName))
            {
                return null;
            }

            try
            {
                var vault = new PasswordVault();
                PasswordCredential pc = vault.Retrieve(resource, userName);
                if (pc != null)
                {
                    pc.RetrievePassword(); 
                    return pc;
                }
                else
                {
                    error($"PasswordCredential not found");
                }
            }
            catch (Exception e)
            {
                error($"Exception thrown {e.Message}");
            }

            return null;
        }

        public bool WritePasswordCredential(string resource, string userName, string password, 
            Action<string> error = null)
        {
            if (string.IsNullOrEmpty(resource)
                || string.IsNullOrEmpty(userName)
                || string.IsNullOrEmpty(password))
            {
                if (error !=null)
                {
                    error($"resource or username or password cannot be null or empty");
                }
                return false;
            }
            try
            {
                var vault = new PasswordVault();
                vault.Add(new PasswordCredential(resource, userName, password));
                return true;
            }
            catch (Exception e)
            {
                if (error != null)
                {
                    error($"Exception thrown {e.Message}");
                }
            }

            return false;
        }

        public bool DeletePasswordCredential(string resource, string userName, 
            Action<string> error = null)
        {
            if (String.IsNullOrEmpty(resource))
            {
                return false;
            }

            try
            {
                var vault = new PasswordVault();

                if (string.IsNullOrEmpty(userName))
                {
                    var credentialList = vault.FindAllByResource(resource);
                    for (int i = 0; i < credentialList.Count; i++)
                    {
                        var c = credentialList[0];
                        vault.Remove(c);
                    }
                    return true;
                }
                else
                {
                    PasswordCredential pc = vault.Retrieve(resource, userName);
                    if (pc != null)
                    {
                        vault.Remove(pc);
                        return true;
                    }
                    else
                    {
                        if (error != null)
                        {
                            error($"PasswordCredential not found");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (error != null)
                {
                    error($"Exception thrown: {e.Message}");
                }
            }

            return false;
        }
    }
}
