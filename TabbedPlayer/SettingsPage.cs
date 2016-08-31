using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			Icon = "Settings35.png";

			Content = new StackLayout
			{
				Padding = new Thickness(20),
				Children = {
					new Label {
						Text = "Settings ContentPage",
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}


