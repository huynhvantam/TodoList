using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoList.Web.Models.UserM;

namespace TodoList.Web.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var users = new List<UserViewM>();
            var url = $"{Common.Common.ApiUrl}/user/getlistuser";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {

                    ((IDisposable)responseStream).Dispose();
                }
                users = JsonConvert.DeserializeObject<List<UserViewM>>(responseData);
            }
            return View(users);
        }
        public IActionResult CreateUser()
        {
            TempData["Done"] = null;
            return View();
        }
        [HttpPost]
        public IActionResult CreateUser(CreateUserM model)
        {
            int result = 0;
            var url = $"{Common.Common.ApiUrl}/user/createuser";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resResult = streamReader.ReadToEnd();
                result = int.Parse(resResult);
            }

            if (result > 0)
            {
                TempData["Done"] = "đã tạo User thành công";
            }
            ModelState.Clear();
            return View(new CreateUserM() { });
        }

        public IActionResult EditUser(int id)
        {
            var user = new EditUserM();
            var url = $"{Common.Common.ApiUrl}/user/getuserbyid/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "GET";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {

                    ((IDisposable)responseStream).Dispose();
                }
                user = JsonConvert.DeserializeObject<EditUserM>(responseData);
            }
            TempData["Done"] = null;
            TempData["Fail"] = null;
            return View(user);
        }
        [HttpPost]
        public IActionResult EditUser(EditUserM model)
        {
            int result = 0;
            var url = $"{Common.Common.ApiUrl}/user/edituser";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "PUT";
            using (var streamWrite = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                var json = JsonConvert.SerializeObject(model);
                streamWrite.Write(json);
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resResult = streamReader.ReadToEnd();
                result = int.Parse(resResult);
            }

            if (result > 0)
            {
                TempData["Done"] = "đã cập nhật User thành công";
                ModelState.Clear();
            }
            else
            {
                TempData["Fail"] = "đã cập nhật User thành công";
            }

            return View(new EditUserM() { });
        }
        public IActionResult DeleteUser(int id)
        {
            var result = false;
            var url = $"{Common.Common.ApiUrl}/user/deleteuser/{id}";
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Method = "DELETE";
            var response = httpWebRequest.GetResponse();
            {
                string responseData;
                Stream responseStream = response.GetResponseStream();
                try
                {
                    StreamReader streamReader = new StreamReader(responseStream);
                    try
                    {
                        responseData = streamReader.ReadToEnd();
                    }
                    finally
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                }
                finally
                {

                    ((IDisposable)responseStream).Dispose();
                }
                result = JsonConvert.DeserializeObject<bool>(responseData);
            }
            return RedirectToAction("Index", "User");
        }
    }
}