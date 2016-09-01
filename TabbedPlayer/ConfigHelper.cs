using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace TabbedPlayer
{
	public static class ConfigHelper
	{
		public const string ConfigurationFile = @"http://www.sheltonlabs.com/WalkFiles/TheWalk.Configuration.xml";

		public static List<MediaData> GetMediaData(string targetName, out string pageTitle, out string bannerSource)
		{
			var config = XDocument.Load(ConfigurationFile);
			var pageConfig = config.Descendants("Page").First((arg) => arg.Attribute("Name").Value.Equals(targetName));
			bannerSource = pageConfig.Attribute("bannerSource").Value;
			pageTitle = pageConfig.Attribute("Title").Value;

			var mediaDatum = new List<MediaData>();
			var mediaContent = pageConfig.Descendants("MediaContent").First();
			foreach (var mediaNode in mediaContent.Descendants())
			{
				// Optional Resource values
				var attrRT = mediaNode.Attribute("ResourceTitle");
				string resourceTitle = attrRT != null ? attrRT.Value : string.Empty;

				var attrRU = mediaNode.Attribute("ResourceUrl");
				string resourceUrl = attrRU != null ? attrRU.Value : string.Empty;

				var md = new MediaData()
				{
					Title = mediaNode.Attribute("Title").Value,
					Detail = mediaNode.Attribute("Detail").Value,
					SourceUrl = mediaNode.Attribute("SourceUrl").Value,
					ThumbnailUrl = mediaNode.Attribute("ThumbnailUrl").Value,
					ResourceTitle = resourceTitle,
					ResourceUrl = resourceUrl
				};

				mediaDatum.Add(md);
			}

			return mediaDatum;
		}
	}
}

