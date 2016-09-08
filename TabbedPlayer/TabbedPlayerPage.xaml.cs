using Xamarin.Forms;

namespace TabbedPlayer
{
	public partial class TabbedPlayerPage : TabbedPage
	{
		public TabbedPlayerPage()
		{
			InitializeComponent();
			// < local:HomePage Title = "Home" />
			// < local:PlayerPage Title = "Walk" />
			// < local:SettingsPage Title = "Settings" />

			Children.Add(new NavigationPage(new HomePage())
			{
				Title = "Home",
				Icon = "Home20.png"
			});

			Children.Add(new NavigationPage(new PlayerPage())
			{
				Title = "Walk",
				Icon = "FootSteps20.png",
			});

			Children.Add(new NavigationPage(new SettingsPage())
			{
				Title = "Settings",
				Icon = "Settings20.png"
			});
		}
	}
}

