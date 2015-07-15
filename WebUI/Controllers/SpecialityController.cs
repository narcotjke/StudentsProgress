using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data;
using BLL.Services;
using BLL.Interfaces;
using AutoMapper;
using WebUI.Models;
using Ninject;

namespace WebUI.Controllers
{
    public class SpecialityController : Controller
    {
        private IService<Speciality> service;

        [Inject]
        public SpecialityController(IService<Speciality> spec)
        {
            service = spec;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<Speciality, SpecialityViewModel>();
            return View(Mapper.Map<IEnumerable<Speciality>, IEnumerable<SpecialityViewModel>>(service.GetAll()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SpecialityViewModel speciality)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Mapper.CreateMap<SpecialityViewModel, Speciality>();
                    if (speciality.SpecialityID > 0)
                        service.Update(Mapper.Map<SpecialityViewModel, Speciality>(speciality));
                    else
                        service.Create(Mapper.Map<SpecialityViewModel, Speciality>(speciality));

                    return RedirectToAction("index");
                }
            }
            catch(DataException dEx)
            {
                ModelState.AddModelError(String.Empty, "Unable to save speciality");
            }
            
            return View(speciality);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id > 0)
            {
                Mapper.CreateMap<Speciality, SpecialityViewModel>();
                var s = Mapper.Map<Speciality, SpecialityViewModel>(service.Get((int)id));

                return View("Create", s);
            }
            else
                return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            service.Delete(id);
            
            return RedirectToAction("Index");
        }
	}
}