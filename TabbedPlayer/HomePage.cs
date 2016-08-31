using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class HomePage : ContentPage
	{
		public HomePage()
		{
			Icon = "Home35.png";

			Content = new StackLayout
			{
				Padding = new Thickness(20),
				Children = {
					new Label {
						Text = "Home ContentPage",
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}


