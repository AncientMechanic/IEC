namespace Infrastructure.IRepositories
{
    public interface ISecurityProvider
    {
        string ISSUER { get; }
        string AUDIENCE { get; }
        string SecurityKey { get; }
        TimeSpan ExpireTime { get; }
    }
}
