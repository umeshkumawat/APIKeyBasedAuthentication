using APIKeyBasedAuthentication.Filters;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIKeyBasedAuthentication.Controllers
{
    [ApiKeyFilter]
    public class SecretController : ControllerBase
    {
        [HttpGet("secret")]
        public IActionResult Secret()
        {
            return Ok("Hello from secret!");
        }
    }
}
