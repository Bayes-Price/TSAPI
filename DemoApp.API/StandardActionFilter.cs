using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoApp.API
{
	/// <summary>
	/// NOTE: This class can intercept every request and perform global processing
	/// such as inspecting request headers or writing detailed logging. It currently
	/// justs logs the request and elapsed time.
	/// </summary>
	public class StandardActionFilter : IActionFilter
	{
		/// <ignore/>
		public void OnActionExecuting(ActionExecutingContext context)
		{
			context.HttpContext.Items.Add("StartTime", DateTime.UtcNow);
			foreach (var header in context.HttpContext.Request.Headers)
			{
				Trace.WriteLine($"header {header.Key}: {header.Value}");
			}
		}

		/// <ignore/>
		public void OnActionExecuted(ActionExecutedContext context)
		{
			DateTime startTime = (DateTime)context.HttpContext.Items["StartTime"]!;
			double secs = DateTime.UtcNow.Subtract(startTime).TotalSeconds;
			Trace.WriteLine($"{DateTime.Now:HH:mm:ss.fff} {context.HttpContext.Request.Method} {context.HttpContext.Request.Path} [{secs:F2}]");
		}
	}
}
