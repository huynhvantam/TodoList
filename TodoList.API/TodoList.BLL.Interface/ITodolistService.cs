using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.BLL.Interface
{
    public interface ITodoListService
    {
        IList<ResTodoList> GetTodoListByUserSV(int userID);
        ResTodoList GetTodoListByIdSV(int Id);
        int CreateTodoListSV(ReqCreateTodoList request);
        int EditTodoListSV(ReqEditTodoList request);
        bool DeleteTodoListSV(int Id);
    }
}
