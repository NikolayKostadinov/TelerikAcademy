using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FileUpload.Data;
using FileUpload.Models.FileModels;
using FileUpload.Models.LogModels;

namespace FileUpload.Infrastructure
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class LogResultFilterAttribute : ActionFilterAttribute
    {
        private static object LockObject = new object();
        private IUowData db;
        /// <summary>
        /// Initializes a new instance of the <see cref="" /> class.
        /// </summary>
        public LogResultFilterAttribute(): this(DependencyResolver.Current.GetService(typeof(IUowData)) as IUowData)
        {
        }

        public LogResultFilterAttribute(IUowData db)
        {
            this.db = db;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var controller = filterContext.Controller;
            IList<string> validationMessages = GetValidationMessages(controller);

            if (filterContext.Result is ContentResult)
            {
                db.TraceLogMessages.Add(CreateTraceLogMessage(filterContext, Status.Error, ((ContentResult)filterContext.Result).Content));
            }
            else if (validationMessages.Count != 0)
            {
                db.TraceLogMessages.Add(CreateTraceLogMessage(filterContext, Status.Warning, string.Join("\n", validationMessages)));
            }
            else
            {
                db.TraceLogMessages.Add(CreateTraceLogMessage(filterContext, Status.Ok));
            }
            base.OnResultExecuted(filterContext);
            lock (LockObject)
            {
                db.SaveChanges();
            }
        }
  
        
        /// <summary>
        /// Creates the trace log message.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="warning">The warning.</param>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        private TraceLogMessage CreateTraceLogMessage(ResultExecutedContext filterContext, Status status, string message = "Ok")
        {
            var controller = filterContext.Controller;
            var traceLogMessage = new TraceLogMessage()
            {
                TimeStamp = DateTime.Now,
                UserName = controller.ControllerContext.RequestContext.HttpContext.User.Identity.Name,
                Controller = controller.ControllerContext.RouteData.Values["controller"].ToString(),
                Action = controller.ControllerContext.RouteData.Values["action"].ToString(),
                Message = message,
                Status = status,
            };
            SaveInTraceLog(filterContext, traceLogMessage);
            return traceLogMessage;
        }
  
        /// <summary>
        /// Saves the in trace log.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <param name="traceLogMessage">The trace log message.</param>
        private void SaveInTraceLog(ResultExecutedContext filterContext, TraceLogMessage traceLogMessage)
        {
            if (traceLogMessage.Status == Status.Ok)
            {
                filterContext.HttpContext.Trace.Write(string.Format("User {0} Controler {1} Action {2} Message{3}", 
                    traceLogMessage.UserName,
                    traceLogMessage.Controller,
                    traceLogMessage.Action,
                    traceLogMessage.Message));
            }
            else 
            {
                filterContext.HttpContext.Trace.Warn(string.Format("User {0} Controler {1} Action {2} Message{3}",
                    traceLogMessage.UserName,
                    traceLogMessage.Controller,
                    traceLogMessage.Action,
                    traceLogMessage.Message)); 
            }
        }

        /// <summary>
        /// Gets the validation messages.
        /// </summary>
        /// <param name="controller">The controller.</param>
        /// <returns></returns>
        private IList<string> GetValidationMessages(ControllerBase inController)
        {
            var controller = (Controller)inController;
            var valigationMessages = new List<string>();
            if (!controller.ModelState.IsValid)
            {
                var result = controller.ModelState.Values;
                foreach (var value in result)
                {
                    if (value.Errors.Count > 0)
                    {
                        foreach (var e in value.Errors)
                        {
                            valigationMessages.Add(e.ErrorMessage);
                        }

                    }
                }
            }
            return valigationMessages;
        }
    }
}