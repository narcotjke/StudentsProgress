using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities;
using System.Data;
using BLL.Interfaces;
using BLL.Services;
using AutoMapper;
using Ninject;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ProgressController : Controller
    {
        private IService<Progress> progressService;
        private IService<Student> studentService;
        private IService<Subject> subjectService;

        [Inject]
        public ProgressController(IService<Progress> serv, IService<Student> studServ, IService<Subject> subjServ)
        {
            progressService = serv;
            studentService = studServ;
            subjectService = subjServ;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<Progress, ProgressViewModel>();
            var progressViewModel = Mapper.Map<IEnumerable<Progress>, IEnumerable<ProgressViewModel>>(progressService.GetAll());

            var ps = progressService.GetAll();
            var pvm = new List<ProgressViewModel>();
            foreach(var p in ps)
            {
                pvm.Add(new ProgressViewModel
                    {
                        ProgressID = p.ProgressID,
                        Mark = p.Mark,
                        Semester = p.Semester,
                        StudentID = p.StudentID,
                        Students = studentService.GetAll().ToList(),
                        Subjects = subjectService.GetAll().ToList(),
                        SubjectID = p.SubjectID
                    });
            }
            return View(pvm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var pvm = new ProgressViewModel
                {
                    Students = studentService.GetAll().ToList(),
                    Subjects = subjectService.GetAll().ToList(),
                };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult Create(ProgressViewModel progress)
        {
            try 
            {
                if(ModelState.IsValid)
                {
                    Mapper.CreateMap<ProgressViewModel, Progress>();
                    if (progress.ProgressID > 0)
                        progressService.Update(Mapper.Map<ProgressViewModel, Progress>(progress));
                    else
                        progressService.Create(Mapper.Map<ProgressViewModel, Progress>(progress));

                    return RedirectToAction("index");
                }
            }
            catch(DataException dEx)
            {
                ModelState.AddModelError("", dEx);
            }

            return RedirectToAction("Create");
            //return View(progress);
        }

        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<Progress, ProgressViewModel>();
            var p = Mapper.Map<Progress, ProgressViewModel>(progressService.Get(id));
            p.Students = studentService.GetAll();
            p.Subjects = subjectService.GetAll();

            return View("create", p);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            progressService.Delete(id);

            return RedirectToAction("Index");
        }
	}
}