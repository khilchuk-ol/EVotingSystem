using System.Numerics;

namespace Shared.Encryption
{
    public struct RsaKey
    {
        public BigInteger exponent;
        public BigInteger module;
    }
}
