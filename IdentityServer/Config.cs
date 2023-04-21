﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
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
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            { };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            { };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                new Client
                {
                    ClientName = "testclient",  
                    ClientId = "testclient",
                    AllowedGrantTypes = GrantTypes.Code , 
                    RedirectUris =  new List<string> { "http://localhost:8100/signin-oidc" },
                    AllowedScopes = { IdentityServerConstants.StandardScopes.OpenId, IdentityServerConstants.StandardScopes.Profile }
                    ,ClientSecrets = {new Secret("UserClientSecret".Sha512()) }
                    ,RequireConsent = true
                }
            };
    }
}