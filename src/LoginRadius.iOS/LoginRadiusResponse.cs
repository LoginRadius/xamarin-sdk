using System;
namespace LoginRadius.SDK
{
	public class LoginRadiusResponse
	{
		public string Action;
		public bool Success;
		public string Response;
		public string Error;

		public LoginRadiusResponse (string action, bool success)
		{
			this.Action = action;
			this.Success = success;
			this.Response = "";
			this.Error = "";	
		}

		public LoginRadiusResponse (string action, bool success, string response)
		{
			this.Action = action;
			this.Success = success;
			this.Response = response;
			this.Error = "";
		}

		public LoginRadiusResponse (string action, bool success, string response, string error)
		{
			this.Action = action;
			this.Success = success;
			this.Response = response;
			this.Error = error;
		}

		public override string ToString ()
		{
			string result = "";
			if (Success) {
				result = string.Format ("[LoginRadiusResponse] Action with {0} succeded with response {1} ", Action, Response);
			} else {
				result = string.Format ("[LoginRadiusResponse] Action with {0} failed with error message {1}", Action, Error);
			}
			return result;
		}

	}
}

