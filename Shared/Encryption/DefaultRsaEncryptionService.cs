using System.Numerics;
using System.Text;

namespace Shared.Encryption
{
    public class DefaultRsaEncryptionService : IRsaEncryptionService
    {
        private const int CHARBITSIZE = sizeof(char) * 8;
        private const int LASTCHAR = (1 << CHARBITSIZE) - 1;

        private readonly RsaKey privateKey;
        private readonly RsaKey publicKey;

        public DefaultRsaEncryptionService(IKeyGenerator keyGenerator)
        {
            var edn = keyGenerator.GenerateEDN();
            privateKey = new RsaKey()
            {
                exponent = edn.Item2,   // d
                module = edn.Item3,     // n
            };
            publicKey = new RsaKey()
            {
                exponent = edn.Item1,   // e
                module = edn.Item3,     // n
            };
        }

        public RsaKey PublicKey => publicKey;

        public async Task<string> ApplyPrivateKeyAsync(string message)
        {
            return await ApplyKey(message, privateKey);
        }

        public async Task<string> ApplyPublicKeyAsync(string message, RsaKey key)
        {
            return await ApplyKey(message, key);
        }

        private static async Task<string> ApplyKey(string message, RsaKey key)
        {
            return await Task.Run(() =>
            {
                var messageInt = StringToBigInt(message);
                var appliedInt = ApplyKey(messageInt, key);
                return BigIntToString(appliedInt);
            });
        }

        public async Task<string> Hash(string message, RsaKey key)
        {
            return await Task.Run(() =>
            {
                BigInteger hashInt = 0;
                Hash(message, key.module, ref hashInt);
                return BigIntToString(hashInt);
            });
        }

        private static BigInteger ApplyKey(BigInteger message, RsaKey key)
        {
            // Simple {message^exponent % module} implementation
            // (1 * 11^19) % 100 = (11 * 11^18) % 100 = (21 * 11^17) % 100 = ...
            BigInteger result = BigInteger.One;
            for (BigInteger i = 0; i < key.exponent; i++)
            {
                result *= message;
                result %= key.module;
            }
            return result;
        }

        private static void Hash(string message, BigInteger module, ref BigInteger hashInt)
        {
            foreach (var letter in message)
            {
                var sum = hashInt + letter;
                hashInt = sum * sum % module;
            }
        }

        private static string BigIntToString(BigInteger bigInt)
        {
            StringBuilder result = new();
            while (bigInt > 0)
            {
                var lastChar = (char)(bigInt & LASTCHAR);
                result.Insert(0, lastChar);
                bigInt >>= CHARBITSIZE;
            }
            return result.ToString();
        }

        private static BigInteger StringToBigInt(string @string)
        {
            BigInteger result = BigInteger.Zero;
            foreach (var ch in @string)
            {
                result <<= CHARBITSIZE;
                result += ch;
            }
            return result;
        }
    }
}
