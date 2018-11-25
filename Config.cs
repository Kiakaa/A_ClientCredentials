using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace A_ClientCredentialsIdServer
{
    class Config
    {
        public static IEnumerable<ApiResource> GetApiResources()//ApiResource需要安装包：Identityserver4
        {
            return new List<ApiResource>
            {
                new ApiResource("api1", "My API")
            };
        }
    }
}
