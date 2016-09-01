using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class MediaPage : ContentPage
	{
		public MediaPage(string title, string sourceUri, string resourceTitle, string resourceUrl)
		{
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

			bool showResourceButton = !string.IsNullOrEmpty(resourceUrl);

			var resourceButton = new Button
			{
				IsEnabled = showResourceButton,
				IsVisible = showResourceButton,
				Text = resourceTitle,
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				HeightRequest = 35				                                 
			};
			resourceButton.Clicked += (object sender, EventArgs e) => { OnMediaButtonClicked(resourceTitle, resourceUrl); };

			var backButton = new Button
			{
				Text = "Back",
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			backButton.Clicked += OnBackButtonClicked;

			Content = new StackLayout
			{
				Padding = new Thickness(0, 20, 0, 20),
				Children = {
					new Label {
						Text = title,
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					browser,
					resourceButton,
					new ShareView(
						sourceUri,
						string.Format("Check out \"{0}\" on The Walk!", title)),
					backButton
				}
			};
		}

		async void OnMediaButtonClicked(string title, string sourceURI)
		{
			await Navigation.PushModalAsync(new MediaPage(title, sourceURI, string.Empty, string.Empty), true);
		}

		async void OnBackButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(true);
		}
	}
}


