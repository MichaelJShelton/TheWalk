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
	}
}


