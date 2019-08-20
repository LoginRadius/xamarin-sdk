namespace XamarinSDK.Models.CustomerAuthentication.Phone
{
    public class PhoneSendOtpModel
    {
        public Data Data { get; set; }
    }
    public class Data
    {
        public string AccountSid { get; set; }
        public string Sid { get; set; }
    }
}
