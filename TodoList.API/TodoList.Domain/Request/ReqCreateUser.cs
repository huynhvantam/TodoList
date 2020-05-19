using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Request
{
    public class ReqCreateUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
