using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.BLL.Interface
{
    public interface IUserService
    {
        IList<ResUser> GetListUserSV();
        ResUser GetUserByIdSV(int Id);
        int CreateUserSV(ReqCreateUser request);
        int EditUserSV(ReqEditUser request);
        bool DeleteUserSV(int Id);
    }
}
