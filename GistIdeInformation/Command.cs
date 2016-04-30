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
		GistIdeInformation
	}

	public class GistCommandHandler : CommandHandler
	{
		protected async override void Run()
		{
			try
			{
				await CreateGist();
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Ok, "Gist created.");	
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
				dictionary.Add("Ide.log", File.ReadAllText(Path.Combine(UserProfile.Current.LogDir, "Ide.log")));

				var client = new GistClient(GistProperties.GitHubUserName, GistProperties.GistPersonalAccessToken);
				var url = client.CreateGist($"{BrandingService.ApplicationName} {MonoDevelop.BuildInfo.Version} 'about information' and log file. - {DateTime.Now.ToLongDateString()}", dictionary);
				DesktopService.ShowUrl(url);
			});
		}

		protected override void Update(CommandInfo info)
		{
			base.Update(info);

			info.Enabled = !string.IsNullOrWhiteSpace(GistProperties.GitHubUserName)
				&& !string.IsNullOrWhiteSpace(GistProperties.GistPersonalAccessToken);
		}
	}
}

