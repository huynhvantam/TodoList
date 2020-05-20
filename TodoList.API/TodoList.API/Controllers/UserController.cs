using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoList.BLL;
using TodoList.BLL.Interface;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.API.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        [Route("api/user/getlistuser")]
        public IEnumerable<ResUser> GetListUserCT()
        {
            return _userService.GetListUserSV();
        }

        // GET: api/User/5
        [HttpGet]
        [Route("api/user/getuserbyid/{id}")]
        public ResUser GetUserByIdCT(int id)
        {
            return _userService.GetUserByIdSV(id);
        }

        // POST: api/User
        [HttpPost]
        [Route("api/user/createuser")]
        public int CreateUserCT([FromBody] ReqCreateUser request)
        {
            return _userService.CreateUserSV(request);
        }

        // PUT: api/User/5
        [HttpPut]
        [Route("api/user/edituser")]
        public int EditUserCT([FromBody] ReqEditUser request)
        {
            return _userService.EditUserSV(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("api/user/deleteuser/{id}")]
        public bool DeleteUserCT(int id)
        {
            return _userService.DeleteUserSV(id);
        }
    }
}
