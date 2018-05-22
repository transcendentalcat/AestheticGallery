using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;
using AestheticGallery.Models;

[assembly: OwinStartup(typeof(AestheticGallery.Startup))]

namespace AestheticGallery
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
                app.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                    LoginPath = new PathString("/Account/Login"),
                });
           
        }
    
    }
}