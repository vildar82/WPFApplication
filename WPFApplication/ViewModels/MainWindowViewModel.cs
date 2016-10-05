using Catel.MVVM;
using System.Threading.Tasks;
using Catel.IoC;
using System;
using Catel.ExceptionHandling;
using Catel.Services;

namespace WPFApplication.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel ()
        {
            var dependencyResolver = this.GetDependencyResolver();
            var exceptionService = dependencyResolver.Resolve<IExceptionService>();
            
            exceptionService.Register<Exception>(exception =>
            {                
                dependencyResolver.Resolve<IMessageService>().ShowAsync("An unknown exception occurred, please contact the developers");
            });

            Test = new TaskCommand(OnTestExecute);
        }               

        public override string Title { get { return "WPFApplication"; } }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        public TaskCommand Test { get; set; }
        private async Task OnTestExecute ()
        {
            // Test exception
            int zero = 0;
            var res = 100 / zero;
        }

        protected override async Task InitializeAsync ()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync ()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
