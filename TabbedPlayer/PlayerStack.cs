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
			Padding = new Thickness(0, 20, 0, 20);
			Children.Add(new Label
			{
				Text = title,
				VerticalOptions = LayoutOptions.StartAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand});
			
			Children.Add(new Image
			{
				Source = bannerSource,
				VerticalOptions = LayoutOptions.FillAndExpand});
			
			Children.Add(new ListView
			{
				HasUnevenRows = false,
				SeparatorVisibility = SeparatorVisibility.None,
				ItemsSource = data,
				ItemTemplate = new DataTemplate(() =>
				{
					var ic = new ImageCell();
					ic.SetBinding(TextCell.TextProperty, "Title");
					ic.SetBinding(TextCell.DetailProperty, "Detail");
					ic.SetBinding(ImageCell.ImageSourceProperty, "ThumbnailUrl");

					ic.Tapped += (object sender, EventArgs e) =>
					{
						var m = data.First((arg) => arg.Title.Equals(ic.Text));
						OnMediaButtonClicked(m.Title, m.SourceUrl, m.ResourceTitle, m.ResourceUrl);
					};

					return ic;
				})});
			
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

