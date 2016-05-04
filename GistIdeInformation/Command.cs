using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Gtk;
using MonoDevelop.Components.Commands;
using MonoDevelop.Core;
using MonoDevelop.Core.Logging;
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
				dictionary.Add("About Information.txt", SystemInformation.GetTextDescription());

				var logFiles = Directory.GetFiles(UserProfile.Current.LogDir, $"*{GetSessionLogFileExtension()}");
				foreach (var logfile in logFiles)
				{
					var logFile = new FileInfo(logfile);
					var tmpLogFile = Path.Combine(Path.GetTempPath(), logFile.Name);
					File.Copy(logFile.FullName, tmpLogFile, true);
					var logContents = File.ReadAllText(tmpLogFile);
					if (!string.IsNullOrWhiteSpace(logContents))
					{
						dictionary.Add(logFile.Name, logContents);
					}
				}

				var client = new GistClient(GistProperties.GitHubUserName, GistProperties.GistPersonalAccessToken);
				url = client.CreateGist($"{BrandingService.ApplicationName} {MonoDevelop.BuildInfo.Version} About Information, Ide{GetSessionLogFileExtension()}, and other log files.", dictionary);
			});
			return url;
		}

		public static bool IsGistAvialable()
		{
			return !string.IsNullOrWhiteSpace(GistProperties.GitHubUserName)
				&& !string.IsNullOrWhiteSpace(GistProperties.GistPersonalAccessToken);
		}

		public static string GetSessionLogFileExtension()
		{
			var getSessionLogFileName = typeof(LoggingService).GetMethod("GetSessionLogFileName", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.NonPublic);
			return (string)getSessionLogFileName.Invoke(null, new[] { string.Empty });
		}
	}

}

