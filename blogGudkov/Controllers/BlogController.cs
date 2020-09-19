using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace blogGudkov.Controllers
{
    /// <summary>
    /// Контроллер страницы блога
    /// </summary>
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
