using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Response
{
    public class ResTodoList
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public string TaskLevel { get; set; }
        public string TaskGroup { get; set; }
        public int UserID { get; set; }
    }
}
