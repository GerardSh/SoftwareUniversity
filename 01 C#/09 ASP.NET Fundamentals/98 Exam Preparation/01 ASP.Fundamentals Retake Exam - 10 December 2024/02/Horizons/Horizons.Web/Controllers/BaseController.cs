﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Horizons.Web.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected string? GetUserId()
        {
            return User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
