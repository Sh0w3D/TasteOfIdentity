using IdentityServer4.Models;


namespace Server
{
    public class Config
    {

        public static IEnumerable<IdentityResource> IdentityResources =>
            new[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource
                {
                    Name = "role",
                    UserClaims = new List<string> { "role" }
                }
            };
        public static IEnumerable<ApiScope> ApiScopes =>
            new[] { new ApiScope("StudentsAPI.read"), new ApiScope("StudentsAPI.write") };

        public static IEnumerable<ApiResource> ApiResources =>
            new[]
            {
                new ApiResource("StudentsAPI")
                {
                    Scopes = new List<string> { "StudentsAPI.read", "StudentsAPI.write"},
                    ApiSecrets = new List<Secret> { new Secret("ScopeSecret".Sha256()) },
                    UserClaims = new List<string> { "role" }
                }
            };

        public static IEnumerable<Client> Clients =>
            new[]
            {
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedScopes = { "StudentsAPI.read", "StudentsAPI.write" }
                },

                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5444/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5444/signin-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5444/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "StudentsAPI.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                },
            };
    }
}
