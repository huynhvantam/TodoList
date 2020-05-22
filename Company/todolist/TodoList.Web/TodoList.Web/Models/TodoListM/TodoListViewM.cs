using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web.Models.TodoListM
{
    public class TodoListViewM
    {
        public int ID { get; set; }
        [Display(Name = "Task Name")]
        public string TaskName { get; set; }
        [Display(Name = "Task Level")]
        public string TaskLevel { get; set; }
        [Display(Name = "Task Group")]
        public string TaskGroup { get; set; }
        [Display(Name = "User")]
        public int UserID { get; set; }
    }
}
