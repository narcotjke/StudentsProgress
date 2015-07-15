using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace WebUI.Models
{
    public class StudentViewModel
    {
        public int StudentID { get; set; }
        [Required, StringLength(50, MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Record book number")]
        public uint RecordBookNumber { get; set; }
        [Required]
        [Display(Name = "Group number")]
        public uint GroupNumber { get; set; }
        [Required(ErrorMessage="Enter birthdate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required]
        [Display(Name = "Speciality")]
        public int SpecialityID { get; set; }

        public List<Speciality> Specialities { get; set; } 

        public StudentViewModel()
        {
            Specialities = new List<Speciality>();
        }
    }
}