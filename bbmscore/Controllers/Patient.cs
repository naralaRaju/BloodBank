using bbmscore.Data;
using bbmscore.Models;
using bbmscore.Models.Domine;
using bbmscore.Models.SmS;
using bbmscore.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Twilio.Types;

namespace bbmscore.Controllers
{
    [Authorize(Roles="Admin")]
    public class Patient : Controller
    {
        private readonly bloodDbcontext bloodDbcontext;
        private readonly SmsService smsService;

        public Patient(bloodDbcontext bloodDbcontext,SmsService smsService)
        {
            this.bloodDbcontext = bloodDbcontext;
            this.smsService = smsService;
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> List()
        {
            var patients = await bloodDbcontext.Patients.ToListAsync();
            var pendingrequests = await bloodDbcontext.pending_Requests.ToListAsync();
            var suceesdata = await bloodDbcontext.receivedData.ToListAsync();
            var model = new CombineofPendingandNewRequests
            {
                Patients = patients,
                pendingRequests = pendingrequests,
                receivedData=suceesdata
            };
            return View(model);
        }
        [HttpGet("BloodRequestData/{id}")]
        public async Task<IActionResult> BloodRequestData(Guid id)
        {
            var patient = await bloodDbcontext.Patients.FirstOrDefaultAsync(x => x.id == id);
            var pendingrequest=await bloodDbcontext.pending_Requests.FirstOrDefaultAsync(x => x.id == id);
            var accepteddata=await bloodDbcontext.receivedData.FirstOrDefaultAsync(x => x.id == id);
            var viewModel = new BloodRequestViewModel
            {
                Patient = patient,
                PendingRequest = pendingrequest,
                receivedData=accepteddata,
                Message = TempData["message"] as string,
                MessageType = TempData["messageType"] as string
            };

            return View(viewModel);
        }
        [HttpPost("Patient/check")]
        public async Task<IActionResult> check(string bloodtype,Guid patientId)
        {
            var result=await bloodDbcontext.Bloodstocks.FirstOrDefaultAsync(t=>t.bloodtype == bloodtype);
            if (result != null)
            {

                if (result.bloodquantity > 0)
                {
                    result.bloodquantity -= 1;
                    
                    var data=await bloodDbcontext.Patients.FirstOrDefaultAsync(x=>x.id== patientId);
                    var pendingdata=await bloodDbcontext.pending_Requests.FirstOrDefaultAsync(x=>x.id== patientId);
                    if(data != null)
                    {
                        string message =  "Blood has been sent.They will reach out you within few hours.Be safe";

                        smsService.SendSms(data.Phone.ToString(),message);
                        bloodDbcontext.receivedData.Add(new ReceivedData
                        {
                            id = data.id,
                            Name = data.Name,
                            Area = data.Area,
                            bloodtype = data.bloodtype,
                            age = data.age,
                            date = DateTime.Today,
                            hospital = data.hospital,
                            Gender = data.Gender,
                            Phone = data.Phone
                        });

                        bloodDbcontext.Patients.Remove(data);
                    }
                    else if (pendingdata != null) 
                    {
                        string message = "Blood has been sent.";
                        smsService.SendSms(pendingdata.Phone.ToString(), message);
                        bloodDbcontext.receivedData.Add(new ReceivedData
                        {
                            id = pendingdata.id,
                            Name = pendingdata.Name,
                            Area = pendingdata.Area,
                            bloodtype = pendingdata.bloodtype,
                            age =pendingdata.age,
                            date = DateTime.Today,
                            hospital =pendingdata.hospital,
                            Gender = pendingdata.Gender,
                            Phone = pendingdata.Phone
                        });

                        bloodDbcontext.pending_Requests.Remove(pendingdata);
                    }
                    await bloodDbcontext.SaveChangesAsync();

                   
                    return RedirectToAction("List");
                   


                }
                else
                {
                    TempData["message"] = "Blood is not available";
                    TempData["messageType"] = "danger";

                    return RedirectToAction("BloodRequestData", new { id = patientId });
                }
                
            }
            TempData["message"] = "Blood is not available";
            TempData["messageType"] = "danger";
            return RedirectToAction("BloodRequestData", new { id = patientId });
        }
        [HttpGet]
        public async Task<IActionResult> Wait(Guid requestid)
        {
            var result=await bloodDbcontext.Patients.FirstOrDefaultAsync(x=>x.id == requestid);
            
            if (result != null)
            {
                var pendingdata = new Pending_Request
                {
                    id= result.id,
                    Name=result.Name,
                    Area=result.Area,
                    bloodtype=result.bloodtype,
                    age=result.age,
                    date=result.date,
                    hospital=result.hospital,
                    Gender=result.Gender,
                    Phone=result.Phone,
                };
                 bloodDbcontext.pending_Requests.Add(pendingdata);
                 bloodDbcontext.Patients.Remove(result);
                await bloodDbcontext.SaveChangesAsync();
               
            }
           
            return RedirectToAction("List");
        }
       
        public async Task<IActionResult>Delete(Guid id)
        {
            var res = await bloodDbcontext.pending_Requests.FirstOrDefaultAsync(x => x.id == id);
            var res1= await bloodDbcontext.Patients.FirstOrDefaultAsync(x => x.id == id);
            var res2 = await bloodDbcontext.receivedData.FirstOrDefaultAsync(x => x.id == id);
            if (res != null)
            {
                bloodDbcontext.pending_Requests.Remove(res);
                bloodDbcontext.SaveChanges();
            }
            else if(res1!=null)
            {
                bloodDbcontext.Patients.Remove(res1);
                bloodDbcontext.SaveChanges();
            }
            else if (res2 != null)
            {
                bloodDbcontext.receivedData.Remove(res2);
                bloodDbcontext.SaveChanges();
            }
            return RedirectToAction("List");
        }
       
    }
}
