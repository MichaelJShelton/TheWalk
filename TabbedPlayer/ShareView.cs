using System;
using Plugin.Share;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class ShareView : Grid
	{
		public ShareView(string link, string message)
		{
			Padding = new Thickness(0);
			BackgroundColor = Color.Transparent;

			// Add an Image and a Transparent Button to each Grid location.
			var shareImage = new Image
			{
				Margin = new Thickness(0),
				HorizontalOptions = LayoutOptions.End,
				HeightRequest = 25,
				WidthRequest = 25,
				MinimumHeightRequest = 25,
				Opacity = .4,
				IsVisible = true,
				Source = ImageSource.FromResource("TabbedPlayer.Resources.share2.png")
			};

			var shareBtn = new Button
			{
				Margin = new Thickness(0),
				HorizontalOptions = LayoutOptions.End,
				HeightRequest = 25,
				WidthRequest = 25,
				MinimumHeightRequest = 25
			};

			shareBtn.Clicked += (sender, e) =>
			{
				// Do Sharing stuff here.
				CrossShare.Current.ShareLink(link, message, "The Walk");
			};

			Children.Add(shareImage, 0, 0);
			Children.Add(shareBtn, 0, 0);
		}
	}
}

