using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Request
{
    public class ReqCreateTodoList
    {

        public string TaskName { get; set; }
        public string TaskLevel { get; set; }
        public string TaskGroup { get; set; }
        public int UserID { get; set; }
    }
}
