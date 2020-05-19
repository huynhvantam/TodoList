using System;
using System.Collections.Generic;
using System.Text;
using TodoList.BLL.Interface;
using TodoList.DAL.Interface;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.BLL
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int CreateUser(ReqCreateUser request)
        {
            return _userRepository.CreateUser(request);
        }

        public bool DeleteUser(int Id)
        {
            return _userRepository.DeleteUser(Id);
        }

        public int EditUser(ReqEditUser request)
        {
            return _userRepository.EditUser(request);
        }

        public IList<ResUser> GetListUser()
        {
            return _userRepository.GetListUser();
        }

        public ResUser GetUserById(int Id)
        {
            return _userRepository.GetUserById(Id);
        }
    }
}
