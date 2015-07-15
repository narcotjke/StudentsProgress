using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;
using BLL.Interfaces;
using BLL.Services;
using Ninject;
using Entities;

namespace WebUI.Controllers
{
    public class SearchController : Controller
    {
        private IService<Student> studentService;
        private IService<Progress> progressService;
        private IService<Speciality> specialityService;

        [Inject]
        public SearchController(IService<Student> serv, IService<Progress> prog, IService<Speciality> spec)
        {
            studentService = serv;
            progressService = prog;
            specialityService = spec;
        }
        public ActionResult Index()
        {
            return View(new SearchOptionsModel
                            {
                                Specialities = specialityService.GetAll()
                                                                .ToList()
                            });
        }

        [HttpGet]
        public ActionResult Search(SearchOptionsModel search)
        {
            int searchOptions = 0;
            IQueryable<Student> students = studentService.GetAll().AsQueryable<Student>();

            if (search.GroupNumber > 0)
            {
                students = students.Where(x => x.GroupNumber == search.GroupNumber);
                searchOptions++;
            }

            if (!string.IsNullOrWhiteSpace(search.Name))
            {
                students = students.Where(s => s.Name.Contains(search.Name));
                searchOptions++;
            }

            if (search.RecordBookNumber > 0)
            {
                students = students.Where(s => s.RecordBookNumber == search.RecordBookNumber);
                searchOptions++;
            }

            if (search.Speciality > 0)
            {
                students = students.Where(s => s.SpecialityID == search.Speciality);
                searchOptions++;
            }

            if (search.Progress >= 4 && search.Progress <= 10)
            {
                var progresses = progressService.GetAll().GroupBy(s => s.StudentID).Where( x => x.Average(p => p.Mark) >= search.Progress).Select(x => x.Key);
                students = students.Where(x => progresses.Contains(x.StudentID));

                searchOptions++;
            }

            return searchOptions > 0 ? View(students) : View();
        }
	}
}