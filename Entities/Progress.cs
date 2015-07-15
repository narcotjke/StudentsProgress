using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Progress
    {
        public int ProgressID { get; set; }
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
        public int Mark { get; set; }
        public int Semester { get; set; }

        public Progress() { }
        public Progress(DAL.Progress progress)
        {
            ProgressID = progress.ProgressID;
            StudentID = progress.StudentID;
            SubjectID = progress.SubjectID;
            Mark = progress.Mark;
            Semester = progress.Semester;
        }
    }
}
