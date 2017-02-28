using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Doctors;
using System.Threading.Tasks;
using Hospital.Core.Patients;
using Hospital.Core.Patients.Models;

namespace Hospital.WebApp.Controllers
{
    public class DoctorsController : Controller
    {
        IDoctorsRepositoryAsync<DoctorDto> _doctorsRepository;
        IPatientsRepositoryAsync<PatientDto> _patientsRepository;
        IDoctorServiceAsync<DoctorDto> _doctorService;

        public DoctorsController(IDoctorsRepositoryAsync<DoctorDto> repository, IPatientsRepositoryAsync<PatientDto> patientsRepository, IDoctorServiceAsync<DoctorDto> doctorService)
        {
            this._doctorsRepository = repository;
            this._patientsRepository = patientsRepository;
            this._doctorService = doctorService;
        }

        public async Task<ActionResult> Index()
        {
            var result = await _doctorsRepository.GetAllAsync();
            return View(result);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new DoctorDto());
        }

        [HttpPost]
        public async Task<ActionResult> Create(DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return View(doctor);
            await _doctorsRepository.CreateAsync(doctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _doctorsRepository.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DoctorDto doctor)
        {
            if (!ModelState.IsValid)
                return View(doctor);
            await _doctorsRepository.UpdateAsync(doctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var result = await _doctorService.GetByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<ActionResult> AddDoctor(int id)
        {
            var result = await _doctorsRepository.GetNotPatientDoctorsAsync(id);
            return View(result);
        }

        public async Task<ActionResult> AddToPatient(int patientId, int doctorId)
        {
            await _doctorsRepository.AddDoctorToPatientAsync(doctorId: doctorId, pacientId: patientId);
            return RedirectToAction("Details", "Patients", new { id = patientId});
        }

        public async Task<ActionResult> Remove(int patientId, int doctorId)
        {
            await _doctorsRepository.RemovePatientAsync(patientId, doctorId);
            var result = await _doctorService.GetByIdAsync(doctorId);
            ViewData.Add("IsDoctorPage","True");
            return PartialView("_PatientsPartial", result.Patients);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            await _doctorsRepository.DeleteAsync(id);
            var result = await _doctorsRepository.GetAllAsync();
            return PartialView("_DoctorsPartial", result);
        }

    }
}