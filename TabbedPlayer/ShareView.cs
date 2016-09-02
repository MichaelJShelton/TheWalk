using System;
using Plugin.Share;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class ShareView : Grid
	{
		public ShareView(string link, string message)
		{
			BackgroundColor = Color.Transparent;
			HorizontalOptions = LayoutOptions.End;
			VerticalOptions = LayoutOptions.End;

			// Add an Image and a Transparent Button to each Grid location.
			Children.Add(
				new Image
				{
					IsVisible = true,
					Source = ImageSource.FromResource("TabbedPlayer.Resources.share2.png"),
					HeightRequest = 45,
					WidthRequest = 45
				}, 0, 0);

			var shareBtn = new Button
			{
				Margin = new Thickness(0),
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				HeightRequest = 65,
				WidthRequest = 65
			};

			shareBtn.Clicked += (sender, e) =>
			{
				// Do Sharing stuff here.
				CrossShare.Current.Share(link, message);
			};

			Children.Add(shareBtn, 0, 0);
		}
	}
}

