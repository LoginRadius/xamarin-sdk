namespace XamarinSDK.Models.CustomerAuthentication.Phone
{
    public class UpdatePhoneResponse
    {
        public BOLSMSResponseData Data { get; set; }
        public string IsPosted { get; set; }
    }

    public class BOLSMSResponseData
    {
        public string AccountSid { get; set; }
        public string Sid { get; set; }
    }
}
