[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Hospital.WebApp.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Hospital.WebApp.App_Start.NinjectWebCommon), "Stop")]

namespace Hospital.WebApp.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Core.Doctors;
    using Core.Doctors.Models;
    using Core.Patients;
    using Core.Patients.Models;
    using Core.Diseases;
    using Core.Diseases.Models;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IDoctorsRepositoryAsync<DoctorDto>>().To<EFDoctorsRepositoryAsync>();
            kernel.Bind<IPatientsRepositoryAsync<PatientDto>>().To<ADOPatientsRepositoryAsync>();
            kernel.Bind<IPatientsServiceAsync<PatientDto>>().To<PatientsServiceAsync>();
            kernel.Bind<IDiseasesRepositoryAsync<DiseaseDto>>().To<ADODiseasesRepositoryAsync>();
            kernel.Bind<IDoctorServiceAsync<DoctorDto>>().To<DoctorServiceAsync>();
        }        
    }
}
