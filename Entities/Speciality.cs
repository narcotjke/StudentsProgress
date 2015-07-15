using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Speciality
    {
        public int SpecialityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Speciality() { }

        public Speciality(DAL.Speciality speciality)
        {
            SpecialityID = speciality.SpecialityID;
            Name = speciality.Name;
            Description = speciality.Description;
        }
    }
}
