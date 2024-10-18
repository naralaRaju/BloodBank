using bbmscore.Data;
using bbmscore.Models.Domine;
using bbmscore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace bbmscore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class BloodBank : Controller
    {
        private readonly bloodDbcontext bloodDbcontext;

        public BloodBank(bloodDbcontext bloodDbcontext )
        {
            this.bloodDbcontext = bloodDbcontext;
        }
       
        [HttpGet]
       
        public async Task<IActionResult> Index()
        {
            var bloodstock = await bloodDbcontext.Bloodstocks.ToListAsync();
            return View(bloodstock);
        }
        [HttpGet]
        public async Task<IActionResult> Donate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Donate(DonorRequest donorRequest)
        {
            var donor = new Donor
            {
                Name = donorRequest.Name,
                Organization = donorRequest.Organization,
                age = donorRequest.age,
                Gender = donorRequest.Gender,
                bloodtype = donorRequest.bloodtype,
                date = DateTime.Now
               
            };

            await bloodDbcontext.Donors.AddAsync(donor);

            await bloodDbcontext.SaveChangesAsync();
            if(donorRequest.bloodtype!= null)
            {
                var check=bloodDbcontext.Bloodstocks.FirstOrDefault(t => t.bloodtype == donorRequest.bloodtype.ToString());
                if (check!=null)
                {
                   check.bloodquantity += 1;
                   check.bloodtype = donorRequest.bloodtype;
                   await bloodDbcontext.SaveChangesAsync();
                }
                else
                {
                    var bloodstock = new Bloodstock
                    {
                        bloodquantity = 1,
                        containerno = bloodDbcontext.Bloodstocks.Max(t=>t.containerno)+1,
                        bloodtype = donorRequest.bloodtype,

                    };
                    
                    bloodDbcontext.Bloodstocks.Add(bloodstock);
                    await bloodDbcontext.SaveChangesAsync();
                }
            }
            return RedirectToAction("Index"); 
           
        }
        [HttpGet]
        public async Task<IActionResult> DonorsList()
        {
            var list = await bloodDbcontext.Donors.ToListAsync();
            return View(list);
        }
        [HttpGet]
        public async Task<IActionResult>DonateAgain(Guid id)
        {
            var data = await bloodDbcontext.Donors.FirstOrDefaultAsync(x => x.id == id);
            var check = bloodDbcontext.Bloodstocks.FirstOrDefault(t => t.bloodtype == data.bloodtype.ToString());
            if (check != null)
            {
                check.bloodquantity += 1;
                
                await bloodDbcontext.SaveChangesAsync();
            }
            else
            {
                var bloodstock = new Bloodstock
                {
                    bloodquantity = 1,
                    containerno = bloodDbcontext.Bloodstocks.Max(t => t.containerno) + 1,
                    bloodtype = data.bloodtype,

                };

                bloodDbcontext.Bloodstocks.Add(bloodstock);
                await bloodDbcontext.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
