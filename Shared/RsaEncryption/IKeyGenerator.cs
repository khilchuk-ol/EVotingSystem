using System.Numerics;

namespace Shared.RsaEncryption
{
    public interface IKeyGenerator
    {
        (BigInteger, BigInteger, BigInteger) GenerateEDN();
    }
}
