﻿using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models.ApiRequest;
using OnlineShop.Models.Options;
using OnlineShop.Models.Repository;
using OnlineShop.Repositories;
using OnlineShop.Services;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserRepository m_Service;
        private readonly AccountService m_accountService;
        
        public AccountController(AccountService accountService)
        {
            m_accountService = accountService;
        }
        [HttpPost("[action]")]
        public TokenData Login(Login login)
        {
            return m_accountService.Token(login.NickName,login.Password );
        }
        [Authorize]
        [HttpPost("[action]")]

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
