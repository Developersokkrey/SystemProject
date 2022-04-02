using KEDI.Core.Cryptography;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace KEDI.Core.Repository
{
    public class SecurityManager
    {
        readonly ILogger<SecurityManager> _logger;
        readonly IConfiguration _config;
        public SecurityManager(ILogger<SecurityManager> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public void ExportRsaKeys(out string privateKeyXml, out string publicKeyXml)
        {
            RsaSecurity.TryExportKeys(out string _privXml, out string _pubXml);
            privateKeyXml = _privXml;
            publicKeyXml = _pubXml;
        }

        public string GetRsaXmlString(bool includedPrivateKey = false)
        {
            try {
                string key = _config["RSA"];
                string[] keys = key.Split(".");
                string privateKey = AesSecurity.Decrypt(keys[0], string.Empty);
                string publicKey = AesSecurity.Decrypt(keys[1], string.Empty);
                if (includedPrivateKey)
                {
                    return privateKey;
                }
                return publicKey;
            }
            catch { return string.Empty; }
        }

        public void TryComputeHash(string data, out string accessToken, out string securityStamp)
        {
            HashSecurity.TryCompute(data,
                   out string _accessToken, out string _securityStamp);
            accessToken = _accessToken;
            securityStamp = _securityStamp;
        }

        public bool VerifyHash(string data, string accessToken, string securityStamp)
        {
            return HashSecurity.Verify(data, accessToken, securityStamp);
        }

        public string Encrypt(string plainText)
        {
            string publicKey = GetRsaXmlString();
            string cipherText = RsaSecurity.Encrypt(plainText, publicKey);
            return cipherText;
        }

        public string Decrypt(string cipherText)
        {
            string privateKey = GetRsaXmlString(true);
            string plainText = RsaSecurity.Decrypt(cipherText, privateKey);
            return plainText;
        }

        public string SignData(string data, ReadOnlySpan<char> privateKeyXml)
        {
            return RsaSecurity.SignData(data, privateKeyXml);
        }

        public bool VerifyData(string data, string Signature, ReadOnlySpan<char> publicKeyXml)
        {
            return RsaSecurity.VerifyData(data, Signature, publicKeyXml);
        }
    }
}
