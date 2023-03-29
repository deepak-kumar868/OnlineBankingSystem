using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using EntityLayer;

namespace UILayer.Controllers
{
    public class UIController : Controller
    {
        private HttpClient Client;

        public UIController()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:61413/");
        }
       
        public async Task<IActionResult> Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(UserModel user)
        {
            TokenDetail tokenDtl;

            try
            {
                var res = await Client.PostAsJsonAsync("ValidateUser", user);
                if (res.IsSuccessStatusCode)
                {
                    var data = res.Content.ReadAsStringAsync().Result;
                    tokenDtl = JsonConvert.DeserializeObject<TokenDetail>(data);

                    SaveToken(tokenDtl.Token);

                    return RedirectToAction("AllServices", "AdminView");
                }
            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;

            }


            return View();
        }

        public async Task<IActionResult> RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(UserModel NewUsr)
        {
            UserModel? ExUser;

            try
            {
                var res =await Client.PostAsJsonAsync("RegisterUser", NewUsr);
                if (res.IsSuccessStatusCode)
                {
                    var data =res.Content.ReadAsStringAsync().Result;
                    ExUser = JsonConvert.DeserializeObject<UserModel>(data);
                    if (ExUser != null)
                    {
                        return RedirectToAction("Login", "UI");
                    }
                    else
                    {
                        throw new Exception("User Not Found");
                    }

                }
            }
            catch (Exception ex)
            {
                TempData["err"] = ex.Message;

            }


            return View();

        }

        public async Task<IActionResult> Logout()
        {
            return RedirectToAction("Login");
        }

        private void SaveToken(string token)
        {
            HttpContext.Response.Cookies.Append("Jwt", token);
        }


    }
}
