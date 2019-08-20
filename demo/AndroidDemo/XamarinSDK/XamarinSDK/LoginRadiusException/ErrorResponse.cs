namespace XamarinSDK.LoginRadiusException
{
    public class ErrorResponse
    {
        public string description { get; set; }
        public int errorCode { get; set; }
        public string message { get; set; }
        public bool isProviderError { get; set; }
        public object providerErrorResponse { get; set; }
    }
}
