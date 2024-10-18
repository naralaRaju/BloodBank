using bbmscore.Data;
using bbmscore.Models;
using bbmscore.Models.SmS;
using bbmscore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace bbmscore.Controllers
{
    public class User : Controller
    {
        private readonly bloodDbcontext bloodDbcontext;



        public User(bloodDbcontext bloodDbcontext)
        {
            this.bloodDbcontext = bloodDbcontext;

        }

        [HttpGet]
        public async Task<IActionResult> Request()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Request(PatientRequest patientRequest)
        {
            var patient = new Patients
            {
                Name = patientRequest.Name,
                Phone = patientRequest.Phone,
                age = patientRequest.age,
                Area = patientRequest.Area,
                bloodtype = patientRequest.bloodtype,
                Gender = patientRequest.Gender,
                date = patientRequest.date,
                hospital = patientRequest.hospital,
            };
            bloodDbcontext.Patients.Add(patient);
            bloodDbcontext.SaveChanges();
            return RedirectToAction("Request");
        }
        [HttpGet]
        public async Task<IActionResult> CampDate()
        {
            var data = bloodDbcontext.CampainData.ToList();
            return View(data);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddCamp()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]

        [HttpPost]
        public async Task<IActionResult> AddCamp(CampainRequest campainRequest)
        {
            var Campain = new Campain
            {
                Organazation = campainRequest.Organazation,
                Date = campainRequest.Date,
                OrganizerName = campainRequest.OrganizerName,
                Description = campainRequest.Description,
                Phone = campainRequest.Phone,
            };
            bloodDbcontext.CampainData.Add(Campain);
            bloodDbcontext.SaveChanges();
            return RedirectToAction("AddCamp");

        }

        //write a methode of Edit it will take id as a parameter 
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var result = bloodDbcontext.CampainData.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {

                var editcampain = new EditCampaindata
                {
                    Id = result.Id,
                    Organazation = result.Organazation,
                    Date = result.Date,
                    OrganizerName = result.OrganizerName,
                    Description = result.Description,
                    Phone = result.Phone,
                };
                return View(editcampain);
            }

            return View(null);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(EditCampaindata editcampaindata)
        {
            if (editcampaindata != null)
            {
                var result = bloodDbcontext.CampainData.FirstOrDefault(x => x.Id == editcampaindata.Id);
                if (result != null)
                {


                    result.Id = editcampaindata.Id;

                    result.Organazation = editcampaindata.Organazation;
                    result.Date = editcampaindata.Date;
                    result.OrganizerName = editcampaindata.OrganizerName;
                    result.Description = editcampaindata.Description;
                    result.Phone = editcampaindata.Phone;
                    bloodDbcontext.CampainData.Update(result);
                    bloodDbcontext.SaveChanges();

                }
            }
            return RedirectToAction("CampDate");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = bloodDbcontext.CampainData.FirstOrDefault(x => x.Id == id);
            if (result != null)
            {
                bloodDbcontext.CampainData.Remove(result);
                bloodDbcontext.SaveChanges();
            }
            return RedirectToAction("CampDate");
        }
    }
     
}
