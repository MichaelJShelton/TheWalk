using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xamarin.Forms;

namespace TabbedPlayer
{
	public class PlayerPage : ContentPage
	{
		private const string PageName = "CurrentWalk";

		public PlayerPage()
		{
			Icon = "FootSteps20.png";

			string pageTitle;
			string bannerSource;
			var mediaDatum = ConfigHelper.GetMediaData(PageName, out pageTitle, out bannerSource);

			Content = new PlayerStack(pageTitle, bannerSource, mediaDatum);
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


