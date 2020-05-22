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

        public int CreateUserSV(ReqCreateUser request)
        {
            return _userRepository.CreateUserRP(request);
        }

        public bool DeleteUserSV(int Id)
        {
            return _userRepository.DeleteUserRP(Id);
        }

        public int EditUserSV(ReqEditUser request)
        {
            return _userRepository.EditUserRP(request);
        }

        public IList<ResUser> GetListUserSV()
        {
            return _userRepository.GetListUserRP();
        }

        public ResUser GetUserByIdSV(int Id)
        {
            return _userRepository.GetUserByIdRP(Id);
        }
    }
}
