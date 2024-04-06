using System.ComponentModel;

namespace ISSProject;

public partial class App : Application, INotifyPropertyChanged
{
    public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new AppShell(false, false, false));

    }
}
