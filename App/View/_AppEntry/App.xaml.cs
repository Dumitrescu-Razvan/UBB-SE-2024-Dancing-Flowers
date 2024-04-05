namespace ISSProject;

public partial class App : Application
{
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new AppShell(false, false, false));

    }
}
