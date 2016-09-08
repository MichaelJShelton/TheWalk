using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class MediaPage : ContentPage
	{
		public MediaPage(string title, string sourceUri, string resourceTitle, string resourceUrl)
		{
			NavigationPage.SetHasNavigationBar(this, false);

			var browser = new WebView
			{
				VerticalOptions = LayoutOptions.StartAndExpand,
				Source = sourceUri,
				HeightRequest = 768,
				WidthRequest = 1024
			};

			browser.IsVisible = true;
			browser.IsEnabled = true;
			browser.Focus();

			var buttons = new Grid
			{
				RowDefinitions = new RowDefinitionCollection() { new RowDefinition { Height = new GridLength(1, GridUnitType.Star) } },
				ColumnDefinitions = new ColumnDefinitionCollection()
			};

			bool showResourceButton = !string.IsNullOrEmpty(resourceUrl);
			if (showResourceButton)
			{
				var resourceButton = new Button
				{
					IsEnabled = showResourceButton,
					IsVisible = showResourceButton,
					Text = resourceTitle,
					VerticalOptions = LayoutOptions.StartAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
					HeightRequest = 25,
					Opacity = 0.4,
					TextColor = Color.White,
					BackgroundColor = Color.FromHex("AABDC0")
				};

				resourceButton.Clicked += (object sender, EventArgs e) =>
				{
					Navigation.PushAsync(new MediaPage(resourceTitle, resourceUrl, string.Empty, string.Empty), true);
				};
				buttons.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
				buttons.Children.AddHorizontal(resourceButton);
			}

			Content = new StackLayout
			{
				// Add space to the Top and Bottom of the Player Stack so it is positioned below
				// the top status bar (wifi signal, battery) and above the bottom Tabs in the TabLayout.
				Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, Device.OnPlatform(5, 0, 0)),
				Children = {
					new ShareView(
						sourceUri,
						true,
						true,
						title),
					browser,
					buttons
				}
			};
		}
	}
}


