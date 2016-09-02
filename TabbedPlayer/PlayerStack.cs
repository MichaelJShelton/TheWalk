using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class MediaCell : ViewCell
	{
		private Label titleLabel;

		public MediaCell()
		{
			titleLabel = new Label
			{
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,
				VerticalTextAlignment = TextAlignment.Start,
				HorizontalTextAlignment = TextAlignment.Start,
			};
			titleLabel.SetBinding(Label.TextProperty, "Title");

			var detailLabel = new Label
			{
				// Snuggle up to the Title Label above this Detail Label.
				Margin = new Thickness(0, -25, 0, 0),
				TextColor = Color.FromHex("5593BD"),
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label)),
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				VerticalTextAlignment = TextAlignment.Start,
				HorizontalTextAlignment = TextAlignment.Start,
			};

			detailLabel.SetBinding(Label.TextProperty, "Detail");

			var image = new Image
			{
				Opacity = .4,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center
			};
			image.SetBinding(Image.SourceProperty, "ThumbnailUrl");

			var txtStack = new StackLayout
			{
				Padding = 0
			};

			txtStack.Children.Add(titleLabel);
			txtStack.Children.Add(detailLabel);

			var viewStack = new StackLayout
			{
				// Space between the Image and the Text.
				Spacing = 10,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center,
				Orientation = StackOrientation.Horizontal
			};
			viewStack.Children.Add(image);
			viewStack.Children.Add(txtStack);

			View = viewStack;
		}

		public string Text
		{
			get { return titleLabel.Text; }
		}
	}

	public class PlayerStack : StackLayout
	{
		public PlayerStack(string title, string bannerSource, List<MediaData> data)
		{
			// Add space to the Top and Bottom of the Player Stack so it is positioned below
			// the top status bar (wifi signal, battery) and above the bottom Tabs in the TabLayout.
			Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, Device.OnPlatform(20, 0, 0));
			Children.Add(new Label
			{
				Text = title,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand
			});
			
			Children.Add(new Image
			{
				Source = bannerSource,
				VerticalOptions = LayoutOptions.FillAndExpand
			});

			var mediaList = new ListView
			{
				HasUnevenRows = true,
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
			
			Children.Add(
				new ShareView(
					"http://goonthewalk.com/app",
					string.Format("Check out \"{0}\" on The Walk!", title)));
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

