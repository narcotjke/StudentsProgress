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
    public class ProgressService: IService<Progress>
    {
        private IUnitOfWork UnitOfWork;

        [Inject]
        public ProgressService(IUnitOfWork uow)
        {
            UnitOfWork = uow;
        }
        public Progress Get(int id)
        {
            Mapper.CreateMap<DAL.Progress, Progress>();
            return Mapper.Map<DAL.Progress, Progress>(UnitOfWork.ProgressRepository.Read(id));
        }

        public IEnumerable<Progress> GetAll()
        {
            Mapper.CreateMap<DAL.Progress, Progress>();
            return Mapper.Map<IEnumerable<DAL.Progress>, IEnumerable<Progress>>(UnitOfWork.ProgressRepository.GetAll());
        }

        public void Create(Progress entity)
        {
            if(entity != null)
            {
                Mapper.CreateMap<Progress, DAL.Progress>();
                UnitOfWork.ProgressRepository.Create(Mapper.Map<Progress, DAL.Progress>(entity));
                UnitOfWork.Save();
            }
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }


        public void Update(Progress entity)
        {
            Mapper.CreateMap<Progress, DAL.Progress>();
            UnitOfWork.ProgressRepository.Update(Mapper.Map<Progress, DAL.Progress>(entity));
            UnitOfWork.Save();
        }


        public void Delete(int id)
        {
            UnitOfWork.ProgressRepository.Delete(id);
            UnitOfWork.Save();
        }
    }
}
