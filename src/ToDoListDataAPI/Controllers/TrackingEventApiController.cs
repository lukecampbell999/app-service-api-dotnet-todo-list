using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToDoListDataAPI.Models;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using System.Web.Script.Serialization;

namespace ToDoListDataAPI.Controllers
{
    public class TrackingEventApiController : ApiController
    {

        private static Dictionary<int, TrackingEvent> mockData = new Dictionary<int, TrackingEvent>();
        private static TelemetryClient telemetry = new TelemetryClient();

        static TrackingEventApiController()
        {
            mockData.Add(0, new TrackingEvent { Description = "feed the dog", ApplicationName = "My App" });
            mockData.Add(1, new TrackingEvent { Description = "take the dog on a walk", ApplicationName = "My App 2" });

           
        }


        // GET api/TrackingEventApi/TrackSimpleEvent/app/description/
        /// <summary>
        /// Makes a new event and submits to the ApplicationInsights API
        /// </summary>
        /// <param name="application"></param>
        /// <param name="description"></param>
        /// <returns>TrackingEvent</returns>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found</response>
        [HttpGet]
        [Route("api/TrackingEventApi/TrackSimpleEvent/{application}/{description}/")]
        public TrackingEvent SimpleEventLoggingOperation(string application, string description)
        {
            TrackingEvent tracker = new TrackingEvent();
            tracker.Description = description;
            tracker.ApplicationName = application;
            tracker.ApplicationEventTime = DateTime.Now;
            var json = new JavaScriptSerializer().Serialize(tracker);
            telemetry.Context.Operation.Name = "TrackEvent";
            telemetry.TrackTrace(description,
               SeverityLevel.Information,
               new Dictionary<string, string> { { "event", json } });
            return tracker;
            
        }

        // GET api/TrackingEventApi/TrackSimpleEventWithUser/app/description/userInfo/
        /// <summary>
        /// Makes a new event and submits to the ApplicationInsights API
        /// </summary>
        /// <param name="application"></param>
        /// <param name="description"></param>
        /// <param name="username"></param>
        /// <returns>TrackingEvent</returns>
        [HttpGet]
        [Route("api/TrackingEventApi/TrackSimpleEvent/{application}/{description}/{username}")]
        public TrackingEvent SimpleEventLoggingOperationWithUsername(string application, string description, String username)
        {
            TrackingEvent tracker = new TrackingEvent();
            tracker.Description = description;
            tracker.ApplicationName = application;
            tracker.ApplicationEventTime = DateTime.Now;
            tracker.Username = username;
            telemetry.Context.Operation.Name = "TrackEvent";
            var json = new JavaScriptSerializer().Serialize(tracker);
            telemetry.TrackTrace(description,
               SeverityLevel.Information,
               new Dictionary<string, string> { { "event", json } });
            return tracker;

        }

    }
}
