using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicToDoApi.Models
{
    public class ToDo
    {
        public int Id { get; set; } 
        public string Task { get; set; }

        public bool IsCompleted { get; set; }
    }
}