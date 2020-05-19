using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.BLL.Interface
{
    public interface IUserService
    {
        IList<ResUser> GetListUser();
        ResUser GetUserById(int Id);
        int CreateUser(ReqCreateUser request);
        int EditUser(ReqEditUser request);
        bool DeleteUser(int Id);
    }
}
