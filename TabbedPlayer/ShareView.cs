﻿using System;
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

			// Add a Transparent Button and an Image to each Grid location.
			Children.Add(
				new Image
				{
					IsVisible = true,
					Source = ImageSource.FromResource("TabbedPlayer.Resources.share2.png"),
					HeightRequest = 35,
					WidthRequest = 35
				}, 0, 0);

			var shareBtn = new Button
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				BackgroundColor = Color.Transparent,
				HeightRequest = 35,
				WidthRequest = 35
			};

			shareBtn.Clicked += (sender, e) =>
			{
				// Do Sharing stuff here.
				CrossShare.Current.ShareLink(link, message, "The Walk");
			};

			Children.Add(shareBtn, 0, 0);
		}
	}
}

