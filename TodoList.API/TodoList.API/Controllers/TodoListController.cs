using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using TodoList.BLL.Interface;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.API.Controllers
{

    [ApiController]
    public class TodoListController : ControllerBase
    {
        private readonly ITodoListService _todoListService;
        public TodoListController(ITodoListService todoListService)
        {
            _todoListService = todoListService;
        }
        // GET: api/TodoList
        [HttpGet]
        [Route("api/todolist/gettodolistbyuser/{id}")]
        public IEnumerable<ResTodoList> GetTodoListByUserCT(int id)
        {
            return _todoListService.GetTodoListByUserSV(id);
        }

        // GET: api/TodoList/5
        [HttpGet]
        [Route("api/todolist/gettodolistbyid/{id}")]
        public ResTodoList GetTodoListByIdCT(int id)
        {
            return _todoListService.GetTodoListByIdSV(id);
        }

        // POST: api/TodoList
        [HttpPost]
        [Route("api/todolist/createtodolist")]
        public int PostTodoListCT([FromBody] ReqCreateTodoList request)
        {
            return _todoListService.CreateTodoListSV(request);
        }

        // PUT: api/TodoList/5
        [HttpPut]
        [Route("api/todolist/edittodolist")]
        public int PutTodoListCT([FromBody] ReqEditTodoList request)
        {
            return _todoListService.EditTodoListSV(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("api/todolist/deletetodolist/{id}")]
        public bool DeleteTodoListCT(int id)
        {
            return _todoListService.DeleteTodoListSV(id);
        }
    }
}
