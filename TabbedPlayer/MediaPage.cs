using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class MediaPage : ContentPage
	{
		public MediaPage(string sourceUri)
		{
			var button = new Button
			{
				Text = "Back",
				VerticalOptions = LayoutOptions.EndAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			};
			button.Clicked += OnBackButtonClicked;

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

			Content = new StackLayout
			{
				Children = {
					browser,
					new ShareView(sourceUri, "This is from The Walk App!"),
					button
				}
			};
		}

		async void OnBackButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PopModalAsync(true);
		}
	}
}


