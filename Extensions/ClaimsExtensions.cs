using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BlogApplication.Extensions
{
    public static class ClaimsExtensions
    {
         public static string GetUsername(this ClaimsPrincipal user)
        {

#pragma warning disable CS8602 // Dereference of a possibly null reference.
            return user.Claims.SingleOrDefault(x => x.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
        }
    }
}