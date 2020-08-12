using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CustomerManagementSystem.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult Index(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<Microsoft.AspNetCore.Diagnostics.IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "The resource you are looking for cannot be found.";
                    ViewBag.QS = statusCodeResult.OriginalQueryString;
                    ViewBag.Path = statusCodeResult.OriginalPath;
                    break;
                default:
                    break;
            }
            return View("../ErrorHandler/PageNotFound");
        }
    }
}
