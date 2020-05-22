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
    public class TodoListRepository : BaseRepository, ITodoListRepository
    {
        public int CreateTodoListRP(ReqCreateTodoList request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TaskName", request.TaskName);
                parameters.Add("@TaskLevel", request.TaskLevel);
                parameters.Add("@TaskGroup", request.TaskGroup);
                parameters.Add("@UserID", request.UserID);
                var id = SqlMapper.ExecuteScalar<int>(con, "CreateTodoList", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public bool DeleteTodoListRP(int Id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", Id);
                var id = SqlMapper.ExecuteScalar<bool>(con, "DeleteTodoList", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public int EditTodoListRP(ReqEditTodoList request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", request.ID);
                parameters.Add("@TaskName", request.TaskName);
                parameters.Add("@TaskLevel", request.TaskLevel);
                parameters.Add("@TaskGroup", request.TaskGroup);
                parameters.Add("@UserID", request.UserID);
                var id = SqlMapper.ExecuteScalar<int>(con, "EditTodoList", param: parameters, commandType: CommandType.StoredProcedure);
                return id;
            }
            catch (Exception ex)
            {
                throw ex;
                //return 0;
            }
        }

        public ResTodoList GetTodoListByIdRP(int Id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@Id", Id);
            ResTodoList getUserById = SqlMapper.Query<ResTodoList>(con, "GetTodoListById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            return getUserById;
        }

        public IList<ResTodoList> GetTodoListByUserRP(int userID)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UserID", userID);
            IList<ResTodoList> getTodolist = SqlMapper.Query<ResTodoList>(con, "GetTodoListByUser", parameters, commandType: CommandType.StoredProcedure).ToList();
            return getTodolist;
        }
    }
}
