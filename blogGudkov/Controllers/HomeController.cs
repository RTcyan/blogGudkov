using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using blogGudkov.Models;
using Microsoft.Extensions.Options;
using blogGudkov.Options;

namespace blogGudkov.Controllers
{
    /// <summary>
    /// Контроллер домашней страницы
    /// </summary>
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptions<ServerInformation> _serverInformation;

        /// <summary>
        /// Конструктор контроллера
        /// </summary>
        /// <param name="logger">Логгер</param>
        /// <param name="serverInformation">Информация о сервере</param>
        public HomeController(ILogger<HomeController> logger, IOptions<ServerInformation> serverInformation)
        {
            _logger = logger;
            _serverInformation = serverInformation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Вид</returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
