using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class Subject
    {
        public int SubjectID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Subject() { }
        public Subject(DAL.Subject subject)
        {
            SubjectID = subject.SubjectID;
            Name = subject.Name;
            Description = subject.Description;
        }
    }
}
