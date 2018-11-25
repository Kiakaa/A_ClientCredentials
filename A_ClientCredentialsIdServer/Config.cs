using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace A_ClientCredentialsIdServer
{
    class Config
    {
        //1，资源列表
        public static IEnumerable<ApiResource> GetApiResources()//ApiResource需要安装包：Identityserver4
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }
        //客户端列表。
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId = "client",
                    // no interactive user, use the clientid/secret for authentication
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    // secret for authentication
                    ClientSecrets =
                    {
                        new Secret("secret".Sha256())
                    },
                    // scopes that client has access to
                    AllowedScopes = { "api1" }
                }
            };
        }
    }
}
