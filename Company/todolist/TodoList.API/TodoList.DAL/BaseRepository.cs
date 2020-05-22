using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace TodoList.DAL
{
    public class BaseRepository
    {
        protected IDbConnection con;
        public BaseRepository()
        {
            string connectString = @"Data Source=H-AITD202003001\SQLEXPRESS;Initial Catalog=TodoList;Integrated Security=True";
            con = new SqlConnection(connectString);
        }
    }
}
