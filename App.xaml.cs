namespace jlcalderonS6
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new Ventanas.vPrincipal());
        }
    }
}
