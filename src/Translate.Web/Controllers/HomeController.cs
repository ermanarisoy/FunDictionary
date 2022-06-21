using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Translate.Web.Interfaces;
using Translate.Web.Models;

namespace Translate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFunTranslateRepository _funTranslateRepository;


        public HomeController(ILogger<HomeController> logger, IFunTranslateRepository funTranslateRepository)
        {
            _logger = logger;
            _funTranslateRepository = funTranslateRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            return View(_funTranslateRepository.GetAll());
        }

        [HttpPost]
        public ActionResult AddTranslation([FromBody] FunTranslate translate)
        {
            var res = _funTranslateRepository.Add(translate);
            if (res)
                return Content("success");
            else
                return Content("error");
        }

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