using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Repositories;
using DAL;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        GenericRepository<Progress> ProgressRepository { get; }
        GenericRepository<Speciality> SpecialityRepository { get; }
        GenericRepository<Student> StudentRepository { get; }
        GenericRepository<Subject> SubjectRepository { get; }
        void Save();
    }
}
