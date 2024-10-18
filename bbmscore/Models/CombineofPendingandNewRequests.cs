using bbmscore.Controllers;
using bbmscore.Models.Domine;
using bbmscore.Models.ViewModel;

namespace bbmscore.Models
{
    public class CombineofPendingandNewRequests
    {
        public IEnumerable<Patients> Patients { get; set; }
        public IEnumerable<Pending_Request> pendingRequests { get; set; }
        public IEnumerable<ReceivedData> receivedData { get; set; }
    }
}
