using System;
using System.Collections.Generic;
using Plugin.Share;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class PlayerPage : ContentPage
	{
		public PlayerPage()
		{
			var md = new List<MediaData>
			{
				new MediaData
				{
					Title = "Step 1",
					Detail = "Start Your Journey Here.",
					ThumbnailSourceUrl = "http://www.sheltonlabs.com/WalkFiles/EasterButton.jpg",
					MediaSourceUrl = "https://player.vimeo.com/video/159995991"
				},
				new MediaData
				{
					Title = "Step 2",
					Detail = "Listen to the second step.",
					ThumbnailSourceUrl = "http://www.sheltonlabs.com/WalkFiles/HarleyButton.jpg",
					MediaSourceUrl = "http://www.sheltonlabs.com"
				}
			};

			Content = new StackLayout
			{
				Padding = new Thickness(20),
				Children =
				{
					new Label {
						Text = "Come Follow Me!",
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					},
					new ListView
					{
						HasUnevenRows = false,
						SeparatorVisibility = SeparatorVisibility.None,
						ItemsSource = md,
						ItemTemplate = new DataTemplate(() =>
						{
							var ic = new ImageCell();
							ic.SetBinding(ImageCell.ImageSourceProperty, "ThumbnailSourceUrl");
							ic.SetBinding(TextCell.TextProperty, "Title");
							ic.SetBinding(TextCell.DetailProperty, "Detail");
							ic.SetBinding(TextCell.CommandParameterProperty, "MediaSourceUrl");

							ic.Tapped += (object sender, EventArgs e) =>
							{
								OnMediaButtonClicked((string)ic.CommandParameter);
							};

							return ic;
						})
					},
					new ShareView("http://goonthewalk.com/app", "Check out this great app!")
				}
			};
		}

		/// <summary>
		/// On the media button clicked.
		/// </summary>
		/// <remarks>
		/// The child/target page will use this functionality to return back to this main player page.
		///	async void OnBackButtonClicked(object sender, EventArgs e)
		///	{
		///		await Navigation.PopModalAsync();
		///	}
		/// </remarks>
		async void OnMediaButtonClicked(string sourceURI)
		{
			await Navigation.PushModalAsync(new MediaPage(sourceURI), true);
		}
	}
}


