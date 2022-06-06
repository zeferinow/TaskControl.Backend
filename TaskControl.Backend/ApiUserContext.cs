using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TaskControl.Backend.Domain;
using TaskControl.Backend.Extensions;

namespace TaskControl.Backend
{
    public class ApiUserContext : IUserContext
    {
        public ObjectId UserId { get; }
        public long TokenExpirationSeconds { get; }
        public bool EmailUser { get; }

        public ApiUserContext(IHttpContextAccessor httpContextAccessor)
        {
            if(httpContextAccessor.HttpContext != null)
            {
                var userIdentity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
                if (userIdentity.Claims.Any())
                {
                    UserId = (ObjectId)userIdentity.FindFirst(JwtClaims.UserId)?.Value.ToObjectId();
                    TokenExpirationSeconds = long.Parse(userIdentity.FindFirst("exp").Value);
                }
            }
        }
    }
}
