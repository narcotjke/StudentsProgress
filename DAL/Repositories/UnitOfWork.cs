using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private StudentProgressEntities context = new StudentProgressEntities();
        private GenericRepository<Progress> progresRepository;
        private GenericRepository<Speciality> specialityRepository;
        private GenericRepository<Student> studentRepository;
        private GenericRepository<Subject> subjectRepository;

        public GenericRepository<Progress> ProgressRepository
        {
            get
            {
                if (progresRepository == null)
                    progresRepository = new GenericRepository<Progress>(context);
                return progresRepository;
            }
        }

        public GenericRepository<Speciality> SpecialityRepository
        {
            get
            {
                if (specialityRepository == null)
                    specialityRepository = new GenericRepository<Speciality>(context);
                return specialityRepository;
            }
        }

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new GenericRepository<Student>(context);
                return studentRepository;
            }
        }

        public GenericRepository<Subject> SubjectRepository
        {
            get
            {
                if (subjectRepository == null)
                    subjectRepository = new GenericRepository<Subject>(context);
                return subjectRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
            {
                if(disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
