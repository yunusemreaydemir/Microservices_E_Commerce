﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace CasgemMicroservice.IdentityServer
{
    public static class Config
    {    //eklendi
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
            new ApiResource("resource_catalog"){Scopes = {"catalog_fullpermission"}},
                new ApiResource("resource_photoStock"){Scopes={"photostock_fullpermission"}},
                    new ApiResource("resource_basket"){Scopes={"basket_fullpermission"}},
                    new ApiResource("resource_discount"){Scopes={"discount_fullpermission"}},
                     new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };


        public static IEnumerable<IdentityResource> IdentityResources =>
                   new IdentityResource[]
                   {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email()
                   };
        //eklendi
        public static IEnumerable<ApiScope> ApiScopes =>
            new ApiScope[]
            {
                new ApiScope ( "catalog_fullpermission", "Ürün Listesi İçin Tam Erişim" ),
                new ApiScope ( "photostock_fullpermission", "Fotoğraf İşlemleri İçin Tam Erişim" ),
                new ApiScope ("basket_fullpermission", "Sepet İçin Tam Erişim"),
                new ApiScope ("discount_fullpermission", "İndirim İşlemleri İçin Tam Erişim"),
                new ApiScope (IdentityServerConstants.LocalApi.ScopeName)
            };

        //eklendi
        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "Casgem1Client",
                    ClientName = "Casgem Client Name",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    AllowedScopes = { "catalog_fullpermission",
                        "photostock_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName}
                },

                new Client
                {
                    ClientId = "Casgem2Client",
                    ClientSecrets = { new Secret("secret".Sha256()) },
                    ClientName = "Casgem 2 Client Name",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                    AllowOfflineAccess = true,
                    AllowedScopes = { "catalog_fullpermission",
                        "basket_fullpermission","photostock_fullpermission","discount_fullpermission",
                        IdentityServerConstants.LocalApi.ScopeName,
                        IdentityServerConstants.StandardScopes.Email,
                        IdentityServerConstants.StandardScopes.OpenId,
                     IdentityServerConstants.StandardScopes.Profile},
                    AccessTokenLifetime = 3600
                },
            };
    }
}