using AppAtividades.Service;
using AppAtividades.View;
using Xamarin.Forms;

namespace AppAtividades
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<IAlertService, AlertService>();

            // abre uma navegacao 
            MainPage = new NavigationPage(new ListAtividadesViewPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
