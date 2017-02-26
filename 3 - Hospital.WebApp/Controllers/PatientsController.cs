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

        // GET: Patients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Patients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public async Task Remove(int patientId, int doctorId)
        {
            await repository.RemoveDoctorAsync(patientId, doctorId);
        }


    }
}
