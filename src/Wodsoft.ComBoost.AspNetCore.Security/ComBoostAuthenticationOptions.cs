﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wodsoft.ComBoost.Security
{
    public class ComBoostAuthenticationOptions : AuthenticationSchemeOptions
    {
        public ComBoostAuthenticationOptions(string loginPath, string logoutPath)
        {
            CookieDomain = c => null;
            CookiePath = c => "/";
            CookieName = c => "ComBoostAuthentication";
            ExpireTime = c => TimeSpan.FromMinutes(15);
            LoginPath = c => loginPath;
            LogoutPath = c => logoutPath;
            AutoUpdate = c => true;
        }

        public ComBoostAuthenticationOptions()
            : this("/Account/Login", "/Account/Logout")
        { }
        
        public ISecureDataFormat<AuthenticationTicket> TicketDataFormat { get; set; }

        public Func<HttpContext, string> CookiePath { get; set; }

        public Func<HttpContext, string> CookieDomain { get; set; }

        public Func<HttpContext, string> CookieName { get; set; }

        public Func<HttpContext, TimeSpan?> ExpireTime { get; set; }

        public Func<HttpContext, string> LoginPath { get; set; }

        public Func<HttpContext, string> LogoutPath { get; set; }

        public Func<HttpContext, bool> AutoUpdate { get; set; }
    }


}
