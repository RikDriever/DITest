using Prism;
using Prism.Ioc;
using DITest.ViewModels;
using DITest.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.DryIoc;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DITest
{
    public partial class App : PrismApplication
    {
        private MyData _myData = new MyData();
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var splashPage = new SplashPage();
            Current.MainPage = splashPage;
        }

        protected override async void OnStart()
        {
            // setting _myData this way will not update the MyData object in the MainPage constructor
            _myData = await MyDataFactory.GetDataAsync();

            // this works
            //MyDataFactory.GetData(ref _myData);

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            _myData.Name = "Name set in RegisterTypes method, this is not the value we want.";
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
            containerRegistry.RegisterInstance(_myData);
        }
    }
}
