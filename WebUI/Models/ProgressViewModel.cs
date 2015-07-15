using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Entities;
using BLL.Interfaces;

namespace WebUI.Models
{
    public class ProgressViewModel
    {
        [ScaffoldColumn(false)]
        public int ProgressID { get; set; }
        [Required(ErrorMessage = "Student is required")]
        [Display(Name = "Student")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Subject is required")]
        [Display(Name = "Subject")]
        public int SubjectID { get; set; }
        [Required]
        [Range(4, 10, ErrorMessage = "Mark must be between 4 and 10")]
        public int Mark { get; set; }
        [Required]
        [Range(1, 9, ErrorMessage = "Semester must be between 1 and 9")]
        public int Semester { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<Student> Students { get; set; }

        [ScaffoldColumn(false)]
        public IEnumerable<Subject> Subjects { get; set; }

        public ProgressViewModel()
        {
            Students = new List<Student>();
            Subjects = new List<Subject>();
        }
    }
}