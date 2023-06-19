using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThirdPartyAuthTest.Filters;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ThirdPartyAuthTest.Controllers
{
    public class TestController : Controller
    {
        [HttpGet]
        [AuthAttribute("Index", "Admin")]
        [Route("sample")]
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return Ok("Action perform successfully!");
        }
    }
}

