using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security;

namespace Business.BusinessAspects.Autofac
{
    /// <summary>
    /// This Aspect control the user's roles in HttpContext by inject the IHttpContextAccessor.
    /// It is checked by writing as [SecuredOperation] on the handler.
    /// If a valid authorization cannot be found in aspect, it throws an exception.
    /// </summary>
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        protected override void OnBefore(IInvocation invocation)
        {

            //var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();            
            //foreach (var role in _roles)
            //{

            //    if (roleClaims.Contains(role))
            //    {
            //        return;
            //    }
            //}
            //throw new Exception(Messages.AuthorizationDenied);

            ///////////////////////////
            var token = _httpContextAccessor.HttpContext.Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            if (token != "")
            {
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(token);
                var decodeToken = jwtSecurityToken.Claims;
                foreach (var claim in decodeToken)
                {
                    foreach (var role in _roles)
                    {
                        if (claim.ToString().Contains(role))
                        {
                            return;
                        }
                    }
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}