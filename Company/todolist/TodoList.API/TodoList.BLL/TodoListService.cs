using System;
using System.Collections.Generic;
using System.Text;
using TodoList.BLL.Interface;
using TodoList.DAL.Interface;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.BLL
{
    public class TodoListService : ITodoListService
    {
        private ITodoListRepository _todoListRepository;
        public TodoListService(ITodoListRepository todoListRepository)
        {
            _todoListRepository = todoListRepository;
        }

        public int CreateTodoListSV(ReqCreateTodoList request)
        {
            return _todoListRepository.CreateTodoListRP(request);
        }

        public bool DeleteTodoListSV(int Id)
        {
            return _todoListRepository.DeleteTodoListRP(Id);
        }

        public int EditTodoListSV(ReqEditTodoList request)
        {
            return _todoListRepository.EditTodoListRP(request);
        }

        public ResTodoList GetTodoListByIdSV(int Id)
        {
            return _todoListRepository.GetTodoListByIdRP(Id);
        }

        public IList<ResTodoList> GetTodoListByUserSV(int userID)
        {
            return _todoListRepository.GetTodoListByUserRP(userID);
        }
    }
}
