using MauiApp1.Front.Components.Pages;
using MauiApp1.Front.Services.Jwt;

namespace MauiApp1.Front
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new MainPage()) { Title = "Healtech" };
        }
    }
}
