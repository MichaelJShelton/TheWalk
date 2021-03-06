﻿using System;

using Xamarin.Forms;

namespace TabbedPlayer
{
	public class SettingsPage : ContentPage
	{
		public SettingsPage()
		{
			NavigationPage.SetHasNavigationBar(this, false);

			Content = new StackLayout
			{
				Padding = new Thickness(0, 20, 0, 20),
				Children = {
					new Label {
						Text = "Settings ContentPage",
						VerticalOptions = LayoutOptions.StartAndExpand,
						HorizontalOptions = LayoutOptions.CenterAndExpand
					}
				}
			};
		}
	}
}


