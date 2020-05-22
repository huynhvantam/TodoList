﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoList.Web.Models.TodoListM
{
    public class UserItem
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
        [Display(Name = "All Task")]
        public int AllTask { get; set; }
    }
}
