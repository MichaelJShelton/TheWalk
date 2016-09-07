using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class PlayerStack : StackLayout
	{
		public PlayerStack(string title, string bannerSource, List<MediaData> data)
		{
			// Add space to the Top and Bottom of the Player Stack so it is positioned below
			// the top status bar (wifi signal, battery) and above the bottom Tabs in the TabLayout.
			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);

			Children.Add(
				new ShareView(
					"http://goonthewalk.com/app",
					string.Format("Check out \"{0}\" on The Walk!", title))
				{
					HorizontalOptions = LayoutOptions.End,
				 	
				});

			Children.Add(new Image
			{
				Source = bannerSource,
				VerticalOptions = LayoutOptions.FillAndExpand
			});

			var mediaList = new ListView(ListViewCachingStrategy.RecycleElement)
			{
				HasUnevenRows = false,
				RowHeight = 65,
				SeparatorVisibility = SeparatorVisibility.Default,
				SeparatorColor = Color.Transparent,
				Margin = new Thickness(10, 0, 0, 10), // Add a little bit of space on the Left and Bottom of the Media ListView.

				ItemsSource = data,
				ItemTemplate = new DataTemplate(() =>
				{
					var mc = new MediaCell();
					mc.Tapped += (object sender, EventArgs e) =>
					{
						var m = data.First((arg) => arg.Title.Equals(mc.Text));
						OnMediaButtonClicked(m.Title, m.SourceUrl, m.ResourceTitle, m.ResourceUrl);
					};

					return mc;
				})
			};
			Children.Add(mediaList);
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
		async void OnMediaButtonClicked(
			string title,
			string sourceURI,
			string resourceTitle,
			string resourceUri)
		{
			await Navigation.PushModalAsync(new MediaPage(title, sourceURI, resourceTitle, resourceUri), true);
		}
	}
}

