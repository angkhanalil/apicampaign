using IdentityServer4.Models;

public static class Config
{
    public static IEnumerable<IdentityResource> GetIdentityResources()
    {
        List<IdentityResource> identityResources = new List<IdentityResource>()
            {
                new IdentityResources.OpenId()
            };

        return identityResources;
    }

    public static IEnumerable<ApiResource> GetApis()
    {
        List<ApiResource> apiResources = new List<ApiResource>()
            {
                new ApiResource("api1", "Test API")
            };

        return apiResources;
    }

    public static IEnumerable<Client> GetClients()
    {
        List<Client> clients = new List<Client>()
            {
                new Client()
                {
                    ClientId = "client1",
                    ClientSecrets =
                    {
                        new Secret("client1Secret".Sha256())
                    },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes =
                    {
                        "api1"
                    }
                }
            };

        return clients;
    }
}