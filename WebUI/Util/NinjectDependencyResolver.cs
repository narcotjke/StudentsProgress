using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces;
using BLL.Services;
using Entities;
using Ninject;
using System.Web.Mvc;

namespace WebUI.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelparam) 
        {
            kernel = kernelparam;
            AddBindings();
        }

        private void AddBindings()
        {
            kernel.Bind<IService<Progress>>().To<ProgressService>();
            kernel.Bind<IService<Speciality>>().To<SpecialityService>();
            kernel.Bind<IService<Student>>().To<StudentService>();
            kernel.Bind<IService<Subject>>().To<SubjectService>();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}