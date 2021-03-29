using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewPersonWeb.Filters;

namespace NewPersonWeb.Controllers
{
    
    [Authorize]
    [AuthorizeActionFilter]
    public class BaseController : Controller
    {
    }
}
