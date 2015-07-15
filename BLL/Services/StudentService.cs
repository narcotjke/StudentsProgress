using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;
using Ninject;

namespace BLL.Services
{
    public class StudentService:IService<Student>
    {
        private IUnitOfWork UnitOfWork;

        [Inject]
        public StudentService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
        public Student Get(int id)
        {
            Mapper.CreateMap<DAL.Student, Student>();
            return Mapper.Map<DAL.Student, Student>(UnitOfWork.StudentRepository.Read(id));
        }

        public IEnumerable<Student> GetAll()
        {
            Mapper.CreateMap<DAL.Student, Student>();
            return Mapper.Map<IEnumerable<DAL.Student>, IEnumerable<Student>>(UnitOfWork.StudentRepository.GetAll());
        }

        public void Create(Student entity)
        {
            if(entity != null)
            {
                Mapper.CreateMap<Student, DAL.Student>();
                UnitOfWork.StudentRepository.Create(Mapper.Map<Student, DAL.Student>(entity));
                UnitOfWork.Save();
            }
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


        public void Update(Student entity)
        {
            Mapper.CreateMap<Student, DAL.Student>();
            UnitOfWork.StudentRepository.Update(Mapper.Map<Student, DAL.Student>(entity));
            UnitOfWork.Save();
        }


        public void Delete(int id)
        {
            UnitOfWork.StudentRepository.Delete(id);
            UnitOfWork.Save();
        }
    }
}
