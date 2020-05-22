using System;
using System.Collections.Generic;
using System.Text;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.DAL.Interface
{
    public interface ITodoListRepository
    {
        IList<ResTodoList> GetTodoListByUserRP(int userID);
        ResTodoList GetTodoListByIdRP(int Id);
        int CreateTodoListRP(ReqCreateTodoList request);
        int EditTodoListRP(ReqEditTodoList request);
        bool DeleteTodoListRP(int Id);

    }
}
