using bbmscore.Models;
using bbmscore.Models.Domine;
using bbmscore.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace bbmscore.Data
{
    public class bloodDbcontext : DbContext
    {
        public bloodDbcontext(DbContextOptions<bloodDbcontext> options) : base(options)
        {
        }
        public DbSet<Bloodstock> Bloodstocks { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Campain> CampainData { get; set; }
        public DbSet<Donor> Donors { get; set; }
        public DbSet<Pending_Request>pending_Requests { get; set; }
        public DbSet<ReceivedData> receivedData { get; set; }
    }
}
