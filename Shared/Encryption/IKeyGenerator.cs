using System.Numerics;

namespace Shared.Encryption
{
    public interface IKeyGenerator
    {
        (BigInteger, BigInteger, BigInteger) GenerateEDN();
    }
}
