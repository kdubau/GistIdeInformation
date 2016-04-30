using System;
using MonoDevelop.Components;
using MonoDevelop.Core;
using MonoDevelop.Ide.Gui.Dialogs;

namespace GistIdeInformation
{
	[System.ComponentModel.ToolboxItem(true)]
	public partial class GistUserInfoPanelWidget : Gtk.Bin
	{
		
		public GistUserInfoPanelWidget()
		{
			this.Build();
			gitHubUserNameEntry.Text = GistProperties.GitHubUserName;
			gistPatEntry.Text = GistProperties.GistPersonalAccessToken;
		}

		public void Save()
		{
			GistProperties.GitHubUserName = gitHubUserNameEntry.Text;
			GistProperties.GistPersonalAccessToken = gistPatEntry.Text;
		}
	}

	class GistUserInfoPanel : OptionsPanel
	{
		GistUserInfoPanelWidget widget;

		public override Control CreatePanelWidget()
		{
			return widget = new GistUserInfoPanelWidget();
		}

		public override void ApplyChanges()
		{
			widget.Save();
		}
	}
}

