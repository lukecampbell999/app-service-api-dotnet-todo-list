using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListDataAPI.Models
{
    public class ErrorResource
    {

        public string Description { get; set; }
        public int ErrorCode { get; set; }
    }
}