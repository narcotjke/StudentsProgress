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
    public class SpecialityService:IService<Speciality>
    {
        private IUnitOfWork UnitOfWork { get; set; }

        [Inject]
        public SpecialityService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
        public Speciality Get(int id)
        {
            Mapper.CreateMap<DAL.Speciality, Speciality>();
            return Mapper.Map<DAL.Speciality, Speciality>(UnitOfWork.SpecialityRepository.Read(id));
        }

        public IEnumerable<Speciality> GetAll()
        {
            Mapper.CreateMap<DAL.Speciality, Speciality>();

            return Mapper.Map<IEnumerable<DAL.Speciality>, IEnumerable<Speciality>>(UnitOfWork.SpecialityRepository.GetAll());
        }

        public void Create(Speciality entity)
        {
            if(entity != null)
            {
                Mapper.CreateMap<Speciality, DAL.Speciality>();
                var s = Mapper.Map<Speciality, DAL.Speciality>(entity);
                UnitOfWork.SpecialityRepository.Create(s);
                UnitOfWork.Save();
            }
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


        public void Update(Speciality entity)
        {
            Mapper.CreateMap<Speciality, DAL.Speciality>();
            UnitOfWork.SpecialityRepository.Update(Mapper.Map<Speciality, DAL.Speciality>(entity));
            UnitOfWork.Save();
        }


        public void Delete(int id)
        {
            UnitOfWork.SpecialityRepository.Delete(id);
            UnitOfWork.Save();
        }
    }
}
