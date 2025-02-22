using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using My_Shop_Framework.Infrastructure;
using Newtonsoft.Json;
using AuthenticationProperties = Microsoft.AspNetCore.Authentication.AuthenticationProperties;

namespace My_Shop_Framework.Application
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void SignIn(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Name),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.UserName),
                new Claim("Mobile", account.Mobile),
                new Claim("ProfilePicture", account.ProfilePicture),
                new Claim("Permission", permissions)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(2)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity is { IsAuthenticated: true };
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            //return claims.Count > 0;
        }

        public string CurrentAccount()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            return null;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;
            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            var value = claims.FirstOrDefault(x => x.Type == "AccountId")?.Value;
            if (value != null)
                result.Id = long.Parse(value);
            result.UserName = claims.FirstOrDefault(x => x.Type == "Username")?.Value;
            result.RoleId = long.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)!.Value);
            result.Mobile = claims.FirstOrDefault(x => x.Type == "Mobile")!.Value;
            result.Name = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)!.Value;
            result.Role = RolesList.GetRoleBy(result.RoleId);
            result.ProfilePicture = claims.FirstOrDefault(x => x.Type == "ProfilePicture")!.Value;
            return result;
        }

        public List<long> GetPermissions()
        {
            if (!IsAuthenticated())
                return null;
            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Permission")
                .Value;
            return JsonConvert.DeserializeObject<List<long>>(permissions);
        }

        public long CurrentAccountId()
        {
            if (IsAuthenticated())
            {
                var value = _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == "AccountId")?.Value;
                if (value != null)
                    return long.Parse(value);
            }

            return 0;
        }

        public string CurrentMobile()
        {
            if (IsAuthenticated())
            {
                var value = _contextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(x => x.Type == "Mobile")?.Value;
                if (value != null)
                    return value;
            }

            return null;
        }
    }
}