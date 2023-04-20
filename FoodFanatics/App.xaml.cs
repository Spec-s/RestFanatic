using FoodFanatics.Services;
using FoodFanatics.Views;

namespace FoodFanatics;

public partial class App : Application
{
	
	public App( )
	{
		InitializeComponent();

		//MainPage = new AppShell();

		/*below is the newly defined navigaton
		 * this page will be the first to launch when opening the application
		 */

		MainPage = new NavigationPage(new LoginPage());
		
	}
}
