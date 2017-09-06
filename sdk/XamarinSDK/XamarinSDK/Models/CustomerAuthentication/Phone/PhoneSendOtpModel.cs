using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
