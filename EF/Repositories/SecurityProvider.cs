using Infrastructure.IRepositories;

namespace EF.Repositories
{
    public class SecurityProvider : ISecurityProvider
    {
        public string ISSUER => "MyAuthServer";

        public string AUDIENCE => "MyAuthClient";

        public string SecurityKey => "mysupersecret_secretkey!123";

        public TimeSpan ExpireTime => TimeSpan.FromMinutes(2);
    }
}