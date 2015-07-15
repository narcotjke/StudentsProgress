using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public uint RecordBookNumber { get; set; }
        public uint GroupNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public int SpecialityID { get; set; }

        public Student() { }
        public Student(DAL.Student student)
        {
            StudentID = student.StudentID;
            Name = student.Name;
            RecordBookNumber = (uint)student.RecordBookNumber;
            GroupNumber = (uint)student.GroupNumber;
            BirthDate = student.BirthDate;
            SpecialityID = student.SpecialityID;
        }
    }
}
