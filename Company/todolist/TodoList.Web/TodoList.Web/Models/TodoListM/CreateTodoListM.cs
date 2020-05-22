using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web.Models.TodoListM
{
    public class CreateTodoListM
    {

        [Display(Name = "Task Name")]
        [Required(ErrorMessage = "Bạn phải nhập Task Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Task Name phải nhập từ 2>50 ký tự")]
        public string TaskName { get; set; }
        [Display(Name = "Task Level")]
        [Required(ErrorMessage = "Bạn phải nhập Task Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Task Name phải nhập từ 2>50 ký tự")]
        public string TaskLevel { get; set; }
        [Display(Name = "Task Group")]
        [Required(ErrorMessage = "Bạn phải nhập Task Name")]
        [StringLength(maximumLength: 50, MinimumLength = 2, ErrorMessage = "Task Name phải nhập từ 2>50 ký tự")]
        public string TaskGroup { get; set; }
        [Display(Name = "User")]
        public int UserID { get; set; }
    }
}
