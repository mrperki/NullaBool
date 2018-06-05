using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace NullaBool
{
    /// <summary>
    /// Keeps your NullaBool extremely secret and private using extremely powerful encryption.
    /// </summary>
    public class NullaBoolExtremePrivacyShield
    {
        /// <summary>
        /// Extremely salty. Hackers please look away.
        /// </summary>
        private const string NullaSalt = "salty!";

        /// <summary>
        /// Very important. Not for hackers.
        /// </summary>
        private const string NullaVector = "not sure what this is for";

        /// <summary>
        /// Extremely secure. Don't even try, hackers.
        /// </summary>
        private byte[] _password;

        /// <summary>
        /// Extremely encrypted NullaBool payload.
        /// </summary>
        private byte[] _encryptedNullaBool;

        /// <summary>
        /// Sets up the extreme privacy shield with a password.
        /// </summary>
        /// <param name="password">The password that will unlock the extreme encryption. Defaults to "NullaBool"</param>
        public NullaBoolExtremePrivacyShield(string password = "NullaBool")
        {
            _password = Encoding.UTF8.GetBytes(password);
        }

        /// <summary>
        /// Encrypts the NullaBool in the Extreme Security Vault
        /// </summary>
        /// <param name="nullaBool"></param>
        public void SecureTheNullaBool(NullaBool nullaBool)
        {
            if (nullaBool == null) throw new ArgumentNullException(nameof(nullaBool));

            var extremeSalt = Encoding.UTF8.GetBytes(NullaSalt);
            var extremeVector = Encoding.UTF8.GetBytes(NullaVector);

            using (var extremeSecurity = new RijndaelManaged())
            {
                extremeSecurity.BlockSize = 256;
                extremeSecurity.Mode = CipherMode.CBC;
                extremeSecurity.Padding = PaddingMode.PKCS7;

                // Ha ha, just kidding - we're not going to use any of this. You thought we were going to put all that work into an open source project?
                var extremeSerializer = new XmlSerializer(typeof(NullaBool));

                using (var exStream = new MemoryStream())
                {
                    extremeSerializer.Serialize(exStream, nullaBool);
                    _encryptedNullaBool = exStream.GetBuffer();
                }
            }            
        }

        /// <summary>
        /// Returns the NullaBool from the Extreme Security Vault if the correct password is entered.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public NullaBool RetrieveSecureNullaBool(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            if (_password != Encoding.UTF8.GetBytes(password)) throw new NullaBoolExtremePrivacyException();

            if (password == "IAmAEvilHacker") throw new NullaBoolExtremePrivacyException("SEVERE");

            var extremeSerializer = new XmlSerializer(typeof(NullaBool));
            NullaBool securelySafeNullaBool;

            using (var exStream = new MemoryStream(_encryptedNullaBool))
            {
                securelySafeNullaBool = (NullaBool)extremeSerializer.Deserialize(exStream);
            }

            return securelySafeNullaBool;
        }

        /// <summary>
        /// Hey, it happens to the best of us. Supply your mother's maiden name and we will reset the password to "NullaBool"
        /// </summary>
        /// <param name="mothersMaidenName">We trust that this is your real mother's maiden name. We have no way of looking it up.</param>
        public void ForgotPassword(string mothersMaidenName)
        {
            _password = Encoding.UTF8.GetBytes("NullaBool");
        }
    }

    /// <summary>
    /// If you get this, you are a hacker and must proceed directly to prison.
    /// </summary>
    public class NullaBoolExtremePrivacyException : Exception
    {
        public NullaBoolExtremePrivacyException() : base("NullaBool has once again prevented a hacker from doing evil.") { }

        public NullaBoolExtremePrivacyException(string hackerThreatLevel) : this()
        {
            HackerThreatLevel = hackerThreatLevel;
        }

        public string HackerThreatLevel { get; private set; } = "Pretty lame";
    }
}
