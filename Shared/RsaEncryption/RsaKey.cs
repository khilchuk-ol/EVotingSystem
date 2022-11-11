using System.Numerics;

namespace Shared.RsaEncryption
{
    public struct RsaKey
    {
        public BigInteger exponent;
        public BigInteger module;
    }
}
