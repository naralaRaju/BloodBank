using bbmscore.Controllers;
using bbmscore.Models.Domine;

namespace bbmscore.Models.ViewModel
{
    public class BloodRequestViewModel
    {
       
            public Patients Patient { get; set; }
            public Pending_Request PendingRequest { get; set; }
            public ReceivedData receivedData { get; set; }
            public string Message { get; set; }
            public string MessageType { get; set; }
       
    }
}
