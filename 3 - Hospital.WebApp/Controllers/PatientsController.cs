using Hospital.Core.Patients;
using Hospital.Core.Patients.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Hospital.WebApp.Controllers
{
    public class PatientsController : Controller
    {
        IPatientsRepositoryAsync<PatientDto> repository;
        IPatientsServiceAsync<PatientDto> service;

        public PatientsController(IPatientsRepositoryAsync<PatientDto> repository, IPatientsServiceAsync<PatientDto> service)
        {
            this.repository = repository;
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var result = await repository.GetAllAsync();
            return View(result);
        }

        public async Task<ActionResult> Details(int id)
        {
            var result = await service.GetByIdAsync(id);
            return View(result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PatientDto patient)
        {
            if (!ModelState.IsValid)
                return View(patient);
            await repository.CreateAsync(patient);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Edit(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(PatientDto patient)
        {
            if (!ModelState.IsValid)
                return View(patient);
            await repository.UpdateAsync(patient);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Remove(int patientId, int doctorId)
        {
            await repository.RemoveDoctorAsync(patientId, doctorId);
            var result = await service.GetByIdAsync(patientId);
            ViewData.Add("IsPatientPage", "True");
            return PartialView("_DoctorsPartial", result.Doctors);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await repository.DeleteAsync(id);
            var result = await repository.GetAllAsync();
            return PartialView("_PatientsPartial", result);
        }

        public async Task<ActionResult> Search(string pattern)
        {
            var result = await repository.SearchAsync(pattern);
            return PartialView("_PatientsPartial", result);
        }
    }
}
