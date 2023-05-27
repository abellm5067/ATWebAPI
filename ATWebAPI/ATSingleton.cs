using EFRepository;
using System.Security.Cryptography;
using System.Text;

namespace ATWebAPI
{
    public sealed class ATSingleton
    {
        private ATSingleton()
        {

        }
        public const string MY_VARIABLE_NAME = "MY_VARIABLE_NAME";
        private static ATSingleton _instance = null;
        private static readonly object _myObect = new object();

        public static ATSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_myObect)
                    {
                        if (_instance == null)
                        {
                            _instance = new ATSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
        public string ComputeHash(string password, string salt, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha256 = SHA256.Create();
            var passwordSaltPepper = $"{password}{salt}{MY_VARIABLE_NAME}";
            var byteValue = Encoding.UTF8.GetBytes(passwordSaltPepper);
            var byteHash = sha256.ComputeHash(byteValue);
            var hash = Convert.ToBase64String(byteHash);
            return ComputeHash(hash, salt, iteration - 1);
        }

        public string GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var byteSalt = new byte[16];
            rng.GetBytes(byteSalt);
            var salt = Convert.ToBase64String(byteSalt);
            return salt;
        }

    }
}
