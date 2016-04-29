using System;
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
			catch
			{
				IdeApp.Workbench.StatusBar.ShowMessage(Stock.Cancel, "Failed to create gist.");
			}
		}

		async Task CreateGist()
		{
			await Task.Run(() =>
			{
				var url = GistClient.UploadGist(SystemInformation.GetTextDescription());
				DesktopService.ShowUrl(url);
			});
		}
	}
}

