using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Response
{
    public class ResUser
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int AllTask { get; set; }
    }
}
