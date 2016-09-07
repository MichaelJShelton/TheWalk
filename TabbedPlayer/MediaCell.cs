using System;
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
}

