using Caliburn.Micro;
using MMDesktopUI.Helpers;
using MMDesktopUI.TestsDependencyInjection;
using MMDesktopUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MMDesktopUI
{
    public class Bootstrapper : BootstrapperBase
    {
        private const string VIEWMODEL = "ViewModel";

        // Pour gèrer l'injection de dépendences
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();

            // -- Après avoir ajouter 'PasswordHelper.cs' --
            ConventionManager.AddElementConvention<PasswordBox>(
                    PasswordBoxHelper.BoundPasswordProperty,
                    "Password",
                    "PasswordChanged");
        }

        protected override void Configure()
        {
            _container.Instance(_container);

            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IAPIHelper, APIHelper>();

            //// Pour appliquer l'injection de dépendence
            _container.PerRequest<ICalculations, Calculations>();

            /*
             * Avec la reflection, Dans l'assembly on recherche toutes les classes qui se terminent par ViewModel 
             * Suivant la demande enregistre dans mon container
             * */
            GetType().Assembly.GetTypes()
                .Where(type => type.IsClass)
                .Where(type => type.Name.EndsWith(VIEWMODEL))
                .ToList()
                .ForEach(viewModelType => _container.RegisterPerRequest(
                    viewModelType, viewModelType.ToString(), viewModelType));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);  
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
