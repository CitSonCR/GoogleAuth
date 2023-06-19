using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ThirdPartyAuthTest.Filters
{
    public class AuthorizeAction : IAuthorizationFilter
    {
        private readonly string _actionName;
        private readonly string _roleType;
        public AuthorizeAction(string actionName, string roleType)
        {
            _actionName = actionName;
            _roleType = roleType;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string _roleType = context.HttpContext.Request?.Headers["role"].ToString();
            switch (_actionName)
            {
                case "Index":
                    if (!_roleType.Contains("admin")) context.Result = new JsonResult("Permission denined!");
                    break;
            }
        }
    }
}
