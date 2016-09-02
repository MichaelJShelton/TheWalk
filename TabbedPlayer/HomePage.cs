using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Xamarin.Forms;

namespace TabbedPlayer
{
	/// <summary>
	/// Home Page
	/// BannerSource URL "http://wac.6261.mucdn.net/806261/artwork/images/cdn/673746/960/540/image.jpg"
	/// </summary>
	public class HomePage : ContentPage
	{
		private const string PageName = "Home";

		public HomePage()
		{
			Icon = "Home20.png";

			string pageTitle;
			string bannerSource;
			var mediaDatum = ConfigHelper.GetMediaData(PageName, out pageTitle, out bannerSource);

			Content = new PlayerStack(pageTitle, bannerSource, mediaDatum);
		}
	}
}


