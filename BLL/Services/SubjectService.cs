using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.Infrastructure;
using Entities;
using DAL.Interfaces;
using DAL.Repositories;
using AutoMapper;
using Ninject;

namespace BLL.Services
{
    public class SubjectService:IService<Subject>
    {
        private IUnitOfWork UnitOfWork { get; set; }
        [Inject]
        public SubjectService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
        public Subject Get(int id)
        {
            Mapper.CreateMap<DAL.Subject, Subject>();
            return Mapper.Map<DAL.Subject, Subject>(UnitOfWork.SubjectRepository.Read(id));
        }

        public IEnumerable<Subject> GetAll()
        {
            Mapper.CreateMap<DAL.Subject, Subject>();
            return Mapper.Map<IEnumerable<DAL.Subject>, IEnumerable<Subject>>(UnitOfWork.SubjectRepository.GetAll());
        }

        public void Create(Subject entity)
        {
            if(entity != null)
            {
                Mapper.CreateMap<Subject, DAL.Subject>();
                UnitOfWork.SubjectRepository.Create(Mapper.Map<Subject, DAL.Subject>(entity));
                UnitOfWork.Save();
            }
        }



        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


        public void Update(Subject entity)
        {
            Mapper.CreateMap<Subject, DAL.Subject>();
            UnitOfWork.SubjectRepository.Update(Mapper.Map<Subject, DAL.Subject>(entity));
            UnitOfWork.Save();
        }


        public void Delete(int id)
        {
            UnitOfWork.SubjectRepository.Delete(id);
            UnitOfWork.Save();
        }
    }
}
