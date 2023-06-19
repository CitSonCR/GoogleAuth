using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ThirdPartyAuthTest.Filters
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string actionName, string roleType) : base(typeof(AuthorizeAction))
        {
            Arguments = new object[] {
                actionName,
                roleType
            };
        }
    }
}


