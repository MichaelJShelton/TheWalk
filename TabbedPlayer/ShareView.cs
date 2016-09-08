using System;
using Plugin.Share;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class ShareView : Grid
	{
		public ShareView(string link, bool showBack, bool showTitle, string title)
		{
			ColumnDefinitions = new ColumnDefinitionCollection()
			{
				new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) },
				new ColumnDefinition() { Width = new GridLength(8, GridUnitType.Auto) },
				new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) }
			};

			RowDefinitions = new RowDefinitionCollection()
			{
				new RowDefinition() { Height = new GridLength(1, GridUnitType.Star)}
			};

			Padding = new Thickness(0);
			BackgroundColor = Color.Transparent;


			if (showBack)
			{
				AddResourceImageButtonToLocation(
					0,
					"TabbedPlayer.Resources.Back20.png",
					(sender, e) =>
					{
						Navigation.PopAsync(true);
					});
			}

			if (showTitle)
			{

				var titleLbl = new Label
				{
					Text = title,
					VerticalOptions = LayoutOptions.Start,
					HorizontalOptions = LayoutOptions.CenterAndExpand
				};

				Children.Add(titleLbl, 2, 0);
				SetColumnSpan(titleLbl, 8);
			}

			AddResourceImageButtonToLocation(
				10,
				"TabbedPlayer.Resources.Share20.png",
				(sender, e) =>
				{
					CrossShare.Current.ShareLink(
						link,
						string.Format("Check out \"{0}\" on The Walk!", title),
						"The Walk");
				});
		}

		// Add an Image and a Transparent Button to the Grid location.
		private void AddResourceImageButtonToLocation(int x, string resource, EventHandler clicked)
		{
			var img = new Image
			{
				Margin = new Thickness(0),
				HorizontalOptions = LayoutOptions.End,
				HeightRequest = 25,
				WidthRequest = 25,
				MinimumHeightRequest = 25,
				Opacity = .6,
				IsVisible = true,
				Source = ImageSource.FromResource(resource)
			};

			var btn = new Button
			{
				Margin = new Thickness(0),
				HorizontalOptions = LayoutOptions.End,
				HeightRequest = 25,
				WidthRequest = 25,
				MinimumHeightRequest = 25,
				BackgroundColor = Color.Transparent
			};

			btn.Clicked += clicked;
			Children.Add(img, x, 0);
			Children.Add(btn, x, 0);
		}
	}
}

