using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using BLL.Interfaces;
using BLL.Services;
using Entities;
using WebUI.Models;
using AutoMapper;
using Ninject;

namespace WebUI.Controllers
{
    public class StudentController : Controller
    {
        private IService<Student> studentService;
        private IService<Speciality> specServ;

        [Inject]
        public StudentController(IService<Student> serv, IService<Speciality> spec)
        {
            studentService = serv;
            specServ = spec;
        }
        public ActionResult Index()
        {
            Mapper.CreateMap<Student, StudentViewModel>();
            var studs = Mapper.Map<IEnumerable<Student>, IEnumerable<StudentViewModel>>(studentService.GetAll());
            foreach(var s in studs)
            {
                s.Specialities.Add(specServ.Get(s.SpecialityID));
            }

            return View(studs);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var stud = new StudentViewModel { Specialities = specServ.GetAll().ToList() };
            return View(stud);
        }

        [HttpPost]
        public ActionResult Create(StudentViewModel student)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    Mapper.CreateMap<StudentViewModel, Student>();
                    if (student.StudentID > 0)
                        studentService.Update(Mapper.Map<StudentViewModel, Student>(student));
                    else
                        studentService.Create(Mapper.Map<StudentViewModel, Student>(student));

                    return RedirectToAction("index");
                }
            }
            catch (DataException dEx)
            {
                ModelState.AddModelError("", dEx);
            }

            student.Specialities = specServ.GetAll().ToList();
            return View(student);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Mapper.CreateMap<Student, StudentViewModel>();
            var s = Mapper.Map<Student, StudentViewModel>(studentService.Get(id));
            s.Specialities = specServ.GetAll().ToList();

            return View("Create", s);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                studentService.Delete(id);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return HttpNotFound();
            }
        }
    }
}