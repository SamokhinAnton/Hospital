using Hospital.Core.Diseases;
using Hospital.Core.Diseases.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hospital.WebApp.Controllers
{
    public class DiseasesController : Controller
    {
        IDiseasesRepositoryAsync<DiseaseDto> _repository;

        public DiseasesController(IDiseasesRepositoryAsync<DiseaseDto> repository)
        {
            this._repository = repository;
        }

        public async Task<ContentResult> Close(int id, int doctorId)
        {
            var endAt = DateTime.Now;
            await _repository.CloseDiseaseAsync(id, endAt);
            ViewData.Add("IsDoctorPage", "True");
            return Content(endAt.ToString());
        }

        [HttpGet]
        public ActionResult Create(int patientId, int doctorId)
        {
            return View(new DiseaseDto() { PatientId = patientId, DoctorId = doctorId });
        }

        [HttpPost]
        public async Task<ActionResult> Create(DiseaseDto disease)
        {
            if (!ModelState.IsValid)
                return View(disease);
            await _repository.CreateAsync(disease);
            return RedirectToAction("Details","Doctors", new { id = disease.DoctorId});
        }
    }
}