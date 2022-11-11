namespace Shared.RsaEncryption
{
    public interface IRsaEncryptionService
    {
        RsaKey PublicKey { get; }

        Task<string> ApplyPrivateKeyAsync(string message);
        Task<string> ApplyPublicKeyAsync(string message, RsaKey key);
        Task<string> Hash(string message, RsaKey key);
    }
}
