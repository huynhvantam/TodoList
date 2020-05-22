using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.DAL.Interface
{
    public interface IUserRepository
    {
        IList<ResUser> GetListUserRP();
        ResUser GetUserByIdRP(int Id);
        int CreateUserRP(ReqCreateUser request);
        int EditUserRP(ReqEditUser request);
        bool DeleteUserRP(int Id);
    }
}
