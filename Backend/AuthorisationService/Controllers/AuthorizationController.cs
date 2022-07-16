using Authorization.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Authorization.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthorizationController));
        private readonly IJWTAuthenticationManager jwtAuthenticationManager;

        public AuthorizationController(IJWTAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] PortfolioDetail customer)
        {
            _log4net.Info("Http Post request to Authenticate");
            var tokenString = jwtAuthenticationManager.Authenticate(customer.Email, customer.Password);

            if (tokenString == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(new { token = tokenString,email = customer.Email });
            }

        }
       
        [HttpGet("GetCustomerByEmail/{email}")]
        public ActionResult GetCustomerByEmail(string email)
        {
            _log4net.Info("Http Get request to GetCustomerByEmail");
            var custObj = jwtAuthenticationManager.GetCustomer(email);
            if (custObj == null)
            {
                return BadRequest();
            }
            return Ok(custObj);
        }

    }
}
