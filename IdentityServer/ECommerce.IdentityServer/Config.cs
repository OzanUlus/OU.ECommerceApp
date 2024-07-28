﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;

namespace ECommerce.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]
        {
         new ApiResource("ResourceCatalog"){Scopes={"CatalogFullPermission","CatalogReadPermission"}},
         new ApiResource("ResourceDiscount"){Scopes={"DiscountFullPermission"}},
         new ApiResource("ResourceOrder"){Scopes={"OrderFullPermission"}},
         new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
      {
         new IdentityResources.OpenId(),
         new IdentityResources.Email(),
         new IdentityResources.Profile(),
      };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
      {
         new ApiScope("CatalogFullPermission","Full authority for catalog operations"),
         new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
         new ApiScope("DiscountFullPermission","Full authority for discount operations"),
         new ApiScope("OrderFullPermission","Full authority for order operations"),
         new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
      };

        public static IEnumerable<Client> Clients => new Client[]
        { 
          //Visitor
          new Client
          {
               ClientId = "ECommerceVisitorId",
               ClientName = "ECommerce Visitor User",
               AllowedGrantTypes = GrantTypes.ClientCredentials,
               ClientSecrets = {new Secret("ecommercesecret".Sha256())},
               AllowedScopes = { "DiscountFullPermission" }

          },

          //Manager
          new Client
          {
               ClientId = "ECommerceManagerId",
               ClientName = "ECommerce Manager User",
               AllowedGrantTypes = GrantTypes.ClientCredentials,
               ClientSecrets = {new Secret("ecommercesecret".Sha256())},
               AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission" }

          },

           //Admin
          new Client
          {
               ClientId = "ECommerceAdminId",
               ClientName = "ECommerce Admin User",
               AllowedGrantTypes = GrantTypes.ClientCredentials,
               ClientSecrets = {new Secret("ecommercesecret".Sha256())},
               AllowedScopes = { "CatalogReadPermission", "CatalogFullPermission", "DiscountFullPermission", "OrderFullPermission",
                  IdentityServerConstants.LocalApi.ScopeName,
                  IdentityServerConstants.StandardScopes.Email,
                  IdentityServerConstants.StandardScopes.OpenId,
                  IdentityServerConstants.StandardScopes.Profile
              },
               AccessTokenLifetime = 600

          },
        };
    }
}