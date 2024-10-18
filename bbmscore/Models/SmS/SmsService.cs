using Twilio.Rest.Api.V2010.Account.Usage.Record;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace bbmscore.Models.SmS
{
    
    public class SmsService
    {
        private readonly IConfiguration configuration;
        public SmsService(IConfiguration configuration)
        {
            this.configuration = configuration;
            TwilioClient.Init(configuration["Twilio:Account SID"], configuration["Twilio:Auth Token"]);
        }
       
      public void SendSms(string toPhoneNumber, string message)
        {
            var incomingPhoneNumbers = IncomingPhoneNumberResource.Read();

            bool isVerified = false;

           
            var number = "+91" + toPhoneNumber;
            foreach (var record in incomingPhoneNumbers)
            {
                if (record.PhoneNumber.ToString() == number)
                {
                    isVerified = true;
                    break;
                }
            }
            if (isVerified)
            {
                var message1 = MessageResource.Create(
               body: message,
               from: new Twilio.Types.PhoneNumber(configuration["Twilio:FromPhoneNumber"]),
               to: new Twilio.Types.PhoneNumber(number)
                );
            }
           
        }
    }
}
