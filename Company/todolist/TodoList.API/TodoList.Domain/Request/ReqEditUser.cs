using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Request
{
    public class ReqEditUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
