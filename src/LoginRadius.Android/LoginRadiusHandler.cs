using System;
using System.Threading.Tasks;

namespace LoginRadius.SDK
{
        public class LoginRadiusHandler
        {
                TaskCompletionSource<LoginRadiusResponse> taskCompletionSource;
		string Action;

		public LoginRadiusHandler (TaskCompletionSource<LoginRadiusResponse> taskCoSource, string action)
                {
                        taskCompletionSource = taskCoSource;
			Action = action;
                }

                public void onSuccess (string response)
                {
			taskCompletionSource.SetResult (new LoginRadiusResponse(Action, true, response));
                }

                public void onFailure (string message)
                {
			taskCompletionSource.SetResult (new LoginRadiusResponse (Action, false, "", message));
                }

                public void onCancelled ()
                {
                        taskCompletionSource.SetCanceled ();
                }

        }
}

