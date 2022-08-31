using Blog.Core.DTOs;
using Blog.Web.Models;
using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostService _postService;
        private readonly ICategoryService _categoryService;
        private readonly IUserService _userService;
        public HomeController(ILogger<HomeController> logger, IPostService postService, ICategoryService categoryService, IUserService userService)
        {
            _logger = logger;
            _postService = postService;
            _categoryService = categoryService;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var categoriesWithCount = await _categoryService.GetAllCategoriesWithCount();
            var lastThreePost = await _postService.GetLastNPost(3);
            var cookie = HttpContext.Request.Cookies["token"];
            ViewBag.token = cookie;
            return View(( categoriesWithCount,lastThreePost));
        }

        public async Task<IActionResult> Signout()
        {

            Response.Cookies.Delete("token");
            return RedirectToAction(nameof(HomeController.Index));

        }

        public async Task<IActionResult> Register()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {


            if (ModelState.IsValid)
            {
                var response = await _userService.Register(registerViewModel);
                var content = await response.Content.ReadFromJsonAsync<Response<NoDataDto>>();

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(HomeController.Index));
                }

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    foreach (var item in content.Errors)
                    {

                        ModelState.AddModelError(String.Empty, item);
                    }


                    return View();

                }


                return RedirectToAction("Error", "Home");
            }


            return View();
        }

        public async Task<IActionResult> Login()
        {


            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {


            if (ModelState.IsValid)
            {
                var response = await _userService.Login(loginViewModel);
                var content = await response.Content.ReadFromJsonAsync<Response<TokenViewModel>>();

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Response.Cookies.Append("token", content.Data.AccessToken, new CookieOptions()
                    {
                        Expires = content.Data.AccessTokenExpiration
                    });
                    return RedirectToAction(nameof(HomeController.Index));

                }



                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    foreach (var item in content.Errors)
                    {

                        ModelState.AddModelError(String.Empty, item);
                    }


                    return View();

                }


                return RedirectToAction("Error", "Home");
            }


            return View();
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