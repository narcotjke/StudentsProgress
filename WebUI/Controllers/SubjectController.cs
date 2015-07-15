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
    public class SubjectController : Controller
    {
        private IService<Subject> service;

        [Inject]
        public SubjectController(IService<Subject> serv)
        {
            service = serv;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<Subject, SubjectViewModel>();
            return View(Mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectViewModel>>(service.GetAll()));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SubjectViewModel subjectViewModel)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Mapper.CreateMap<SubjectViewModel, Subject>();
                    if (subjectViewModel.SubjectID > 0)
                        service.Update(Mapper.Map<SubjectViewModel, Subject>(subjectViewModel));
                    else
                        service.Create(Mapper.Map<SubjectViewModel, Subject>(subjectViewModel));

                    return RedirectToAction("Index");
                }
            }
            catch (DataException dEx)
            {
                ModelState.AddModelError("", "Unable to save subject");
            }
            
            return View(subjectViewModel);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<Subject, SubjectViewModel>();
            var s = Mapper.Map<Subject, SubjectViewModel>(service.Get(id));

            return View("Create", s);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            service.Delete(id);

            return RedirectToAction("index");
        }
	}
}