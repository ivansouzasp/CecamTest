using System;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace CECAM.Entities.Security
{
    public class SigningConfiguration
    {
        public SigningConfiguration()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }
            Credentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256);
        }
        public SecurityKey Key { get; set; }
        public SigningCredentials Credentials { get; set; }
    }
}
