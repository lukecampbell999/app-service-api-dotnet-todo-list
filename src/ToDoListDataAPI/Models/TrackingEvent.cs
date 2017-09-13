using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoListDataAPI.Models
{
    public class TrackingEvent
    {
        public string Description { get; set; }
        public string ApplicationName { get; set; }
        public string Username { get; set; }
        public DateTime ApplicationEventTime { get; set; }

    }
}