﻿using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResource(
                    "roles",
                    "Your role(s)",
                    new List<string>() { "role" })
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope("testServer", "Test Server"),
                new ApiScope(name: "read",   displayName: "Read your data."),
                new ApiScope(name: "write",  displayName: "Write your data."),
                new ApiScope(name: "delete", displayName: "Delete your data.")
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {

            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    
                    ClientName = "testclient",  
                    ClientId = "testclient",
                    AllowedCorsOrigins = new List<string> {"http://localhost:8100" },
                    AllowedGrantTypes = GrantTypes.Code , 
                    RedirectUris =  new List<string> { "http://localhost:8100/signin-callback" },
                    PostLogoutRedirectUris  = new List<string> { "http://localhost:8100/signout-callback" },
                    RequireClientSecret = false,
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
                    ,AllowAccessTokensViaBrowser = true
                    //,ClientSecrets = {new Secret("UserClientSecret".Sha512()) }
                    ,RequireConsent = true,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = false,
                    AlwaysSendClientClaims = false,
                    AccessTokenLifetime = 60,
                },
                new Client
                {
                    ClientId = "msaccounts.client",
                    ClientSecrets = { new Secret("yoursecret".Sha256()) },
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    AllowedScopes = { "api1", "api2.read_only" }
                },
                new Client
                {

                    ClientName = "testclient2",
                    ClientId = "testclient2",
                    AllowedCorsOrigins = new List<string> {"http://localhost:3000" },
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    ClientSecrets = new List<Secret> { new Secret { Value = "dummy" } },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile, "role" }
                    ,AllowAccessTokensViaBrowser = true
                    ,RequireClientSecret = false
                    //,ClientSecrets = {new Secret("UserClientSecret".Sha512()) }
                    ,RequireConsent = true,
                    AllowOfflineAccess = true,
                    AlwaysIncludeUserClaimsInIdToken = true,
                    AlwaysSendClientClaims = true,
                    AccessTokenLifetime = 60,
                }
            };
    }
}