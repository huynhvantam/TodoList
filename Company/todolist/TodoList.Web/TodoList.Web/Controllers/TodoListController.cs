using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoList.Web.Models.TodoListM;

namespace TodoList.Web.Controllers
{
    public class TodoListController : Controller
    {
        private static int userIdC = 0;
        public IActionResult Index(int id)
        {
            var todolist = new List<TodoListViewM>();
            var url = $"{Common.Common.ApiUrl}/todolist/gettodolistbyuser/{id}";
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
                todolist = JsonConvert.DeserializeObject<List<TodoListViewM>>(responseData);
            }
            userIdC = id;
            ViewBag.Username = ListUser().Where(p => p.ID == id).FirstOrDefault().Username;
            return View(todolist);
        }
        private List<UserItem> ListUser()
        {
            var users = new List<UserItem>();
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
                users = JsonConvert.DeserializeObject<List<UserItem>>(responseData);
            }
            return users;
        }

        public IActionResult CreateTodoList()
        {
            ViewBag.VGusers = ListUser();
            ViewBag.VGuserid = userIdC;
            return View();
        }
        [HttpPost]
        public IActionResult CreateTodoList(CreateTodoListM model)
        {
            int result = 0;
            var url = $"{Common.Common.ApiUrl}/todolist/createtodolist";
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
                TempData["Done"] = "đã tạo To-do List thành công";
            }
            ModelState.Clear();
            ViewBag.VGusers = ListUser();
            ViewBag.VGuserid = userIdC;
            return View(new CreateTodoListM() { });
        }

        public IActionResult EditTodoList(int id)
        {
            var nhanvien = new EditTodoListM();
            var url = $"{Common.Common.ApiUrl}/todolist/gettodolistbyid/{id}";
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
                nhanvien = JsonConvert.DeserializeObject<EditTodoListM>(responseData);
            }
            ViewBag.VGusers = ListUser();
            ViewBag.VGuserid = userIdC;
            TempData["Done"] = null;
            TempData["Fail"] = null;

            return View(nhanvien);
        }
        [HttpPost]
        public IActionResult EditTodoList(EditTodoListM model)
        {
            int editResult = 0;
            //var url = $"{Common.Common.ApiUrl}/phongban/suaphongban";

            //HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            var httpWebRequest = (HttpWebRequest)WebRequest.Create($"{Common.Common.ApiUrl}/todolist/edittodolist");
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
                var result = streamReader.ReadToEnd();
                editResult = int.Parse(result);
            }
            ViewBag.VGusers = ListUser();
            ViewBag.VGuserid = userIdC;
            if (editResult <= 0)
            {
                TempData["Fail"] = "TeamData sửa  KHÔNG thành công";
                return View(model);
            }
            else
            {
                TempData["Done"] = "TeamData-đã sửa thành công";
                ModelState.Clear();
                return View(new EditTodoListM() { UserID = userIdC });
            }

        }
        public IActionResult DeleteTodoList(int id)
        {
            var result = false;
            var url = $"{Common.Common.ApiUrl}/todolist/deletetodolist/{id}";
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
            return RedirectToAction("Index", "TodoList", new { id = userIdC });

        }
    }
}