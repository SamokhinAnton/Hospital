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

        // GET: Patients/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await service.GetByIdAsync(id);
            return View(result);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patients/Create
        [HttpPost]
        public async Task<ActionResult> Create(PatientDto patient)
        {
            try
            {
                await repository.CreateAsync(patient);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Patients/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return View(result);
        }

        // POST: Patients/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PatientDto patient)
        {
            try
            {
                await repository.UpdateAsync(patient);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
