using System;

namespace TSAPI.ApiBrowser
{
	/// <summary>
	/// A sample class that could become a standard error response for TSAPI web services.
	/// The Red Centre Software service always returns a serialized instance of this class
	/// for non-200 responses. The WPF browser has special logic to detect this response.
	/// The RCS service returns a metadata item that says this response will be returned.
	/// This is all experimental for now.
	/// </summary>
	public class ErrorResponse
	{
		public int Code { get; set; }
		public string Message { get; set; }
		public string Detail { get; set; }
		public string HelpUri { get; set; }
	}
}
