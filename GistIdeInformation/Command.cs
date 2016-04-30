using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Gtk;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Ide;

namespace GistIdeInformation
{
	public enum GistCommands
	{
		GistIdeInformation,
		CopyGistIdeInformation
	}

	public class GistCommandHandler : CommandHandler
	{
		protected async override void Run()
		{
			try
			{
				var gistUrl = await GistCommandHelper.CreateGist();
				DesktopService.ShowUrl(gistUrl);
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Ok, "Gist created.");	
			}
			catch (Exception e)
			{
				LoggingService.LogError("Unable to create Gist.", e);
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Cancel, "Failed to create gist.");
			}
		}

		protected override void Update(CommandInfo info)
		{
			base.Update(info);
			info.Enabled = GistCommandHelper.IsGistAvialable();
		}
	}

	public class CopyGistCommandHandler : CommandHandler
	{
		protected async override void Run()
		{
			try
			{
				var gistUrl = await GistCommandHelper.CreateGist();
				Xwt.Clipboard.SetData(gistUrl);
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Ok, "Gist Url copied to clipboard.");
			}
			catch (Exception e)
			{
				LoggingService.LogError("Unable to create Gist.", e);
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Cancel, "Failed to create gist.");
			}
		}

		async Task CreateGist()
		{
			await Task.Run(() =>
			{
				var dictionary = new Dictionary<string, string>();
				dictionary.Add("AboutInformation.txt", SystemInformation.GetTextDescription());

				var logFile = new FileInfo(Environment.GetEnvironmentVariable("MONODEVELOP_LOG_FILE"));
				dictionary.Add(logFile.Name, File.ReadAllText(logFile.FullName));

				var client = new GistClient(GistProperties.GitHubUserName, GistProperties.GistPersonalAccessToken);
				var url = client.CreateGist($"{BrandingService.ApplicationName} {MonoDevelop.BuildInfo.Version} 'about information' and log file. - {DateTime.Now.ToLongDateString()}", dictionary);
				DesktopService.ShowUrl(url);
			});
		}

		protected override void Update(CommandInfo info)
		{
			base.Update(info);
			info.Enabled = GistCommandHelper.IsGistAvialable();
		}
	}

	class GistCommandHelper
	{
		public static async Task<string> CreateGist()
		{
			string url = string.Empty;
			await Task.Run(() =>
			{
				var dictionary = new Dictionary<string, string>();
				dictionary.Add("AboutInformation.txt", SystemInformation.GetTextDescription());
				dictionary.Add("Ide.log", File.ReadAllText(Path.Combine(UserProfile.Current.LogDir, "Ide.log")));

				var client = new GistClient(GistProperties.GitHubUserName, GistProperties.GistPersonalAccessToken);
				url = client.CreateGist($"{BrandingService.ApplicationName} {MonoDevelop.BuildInfo.Version} 'about information' and log file. - {DateTime.Now.ToLongDateString()}", dictionary);
			});
			return url;
		}

		public static bool IsGistAvialable()
		{
			return !string.IsNullOrWhiteSpace(GistProperties.GitHubUserName)
				&& !string.IsNullOrWhiteSpace(GistProperties.GistPersonalAccessToken);
		}
	}

}

