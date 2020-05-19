using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using TodoList.DAL.Interface;
using TodoList.Domain.Request;
using TodoList.Domain.Response;

namespace TodoList.DAL
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int CreateUser(ReqCreateUser request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Username", request.Username);
                parameters.Add("@Password", request.Password);
                var id = SqlMapper.ExecuteScalar<int>(con, "CreateUser", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public bool DeleteUser(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var id = SqlMapper.ExecuteScalar<bool>(con, "DeleteUser", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public int EditUser(ReqEditUser request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.ID);
                parameters.Add("@Username", request.Username);
                parameters.Add("@Password", request.Password);
                var id = SqlMapper.ExecuteScalar<int>(con, "EditUser", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public IList<ResUser> GetListUser()
        {
            IList<ResUser> getListUser = SqlMapper.Query<ResUser>(con, "GetListUser", commandType: CommandType.StoredProcedure).ToList();
            return getListUser;
        }

        public ResUser GetUserById(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            ResUser getUserById = SqlMapper.Query<ResUser>(con, "GetUserById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return getUserById;
        }
    }
}
