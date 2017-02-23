using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hospital.Core.Doctors.Models;
using Hospital.Core.Doctors;
using System.Threading.Tasks;

namespace Hospital.WebApp.Controllers
{
    public class DoctorsController : Controller
    {
        IDoctorsRepositoryAsync<DoctorDto> repository;

        public DoctorsController(IDoctorsRepositoryAsync<DoctorDto> repository)
        {
            this.repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            var result = await repository.GetAllAsync();
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
            await repository.CreateAsync(doctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(DoctorDto doctor)
        {
            await repository.UpdateAsync(doctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            var result = await repository.GetByIdAsync(id);
            return View(result);
        }

    }
}