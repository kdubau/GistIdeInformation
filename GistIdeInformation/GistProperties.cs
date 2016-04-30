using System;
using MonoDevelop.Core;

namespace GistIdeInformation
{
	public class GistProperties
	{
		private const string gitHubUserName = "GistIdeInformation.GitHubUserName";
		private const string gistPersonalAccessToken = "GistIdeInformation.GistPersonalAccessToken";

		public static string GitHubUserName
		{
			get
			{
				return PropertyService.Get(gitHubUserName, "");
			}
			internal set
			{
				PropertyService.Set(gitHubUserName, value);
			}
		}

		public static string GistPersonalAccessToken
		{
			get
			{
				return PropertyService.Get(gistPersonalAccessToken, "");
			}
			internal set
			{
				PropertyService.Set(gistPersonalAccessToken, value);
			}
		}
	}
}

