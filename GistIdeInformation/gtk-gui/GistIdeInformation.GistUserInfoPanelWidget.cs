
// This file has been generated by the GUI designer. Do not modify.
namespace GistIdeInformation
{
	public partial class GistUserInfoPanelWidget
	{
		private global::Gtk.Table table1;

		private global::Gtk.Entry gistPatEntry;

		private global::Gtk.Entry gitHubUserNameEntry;

		private global::Gtk.Label label1;

		private global::Gtk.Label label2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget GistIdeInformation.GistUserInfoPanelWidget
			global::Stetic.BinContainer.Attach(this);
			this.Name = "GistIdeInformation.GistUserInfoPanelWidget";
			// Container child GistIdeInformation.GistUserInfoPanelWidget.Gtk.Container+ContainerChild
			this.table1 = new global::Gtk.Table(((uint)(2)), ((uint)(2)), false);
			this.table1.Name = "table1";
			this.table1.RowSpacing = ((uint)(6));
			this.table1.ColumnSpacing = ((uint)(6));
			// Container child table1.Gtk.Table+TableChild
			this.gistPatEntry = new global::Gtk.Entry();
			this.gistPatEntry.CanFocus = true;
			this.gistPatEntry.Name = "gistPatEntry";
			this.gistPatEntry.IsEditable = true;
			this.gistPatEntry.InvisibleChar = '●';
			this.table1.Add(this.gistPatEntry);
			global::Gtk.Table.TableChild w1 = ((global::Gtk.Table.TableChild)(this.table1[this.gistPatEntry]));
			w1.TopAttach = ((uint)(1));
			w1.BottomAttach = ((uint)(2));
			w1.LeftAttach = ((uint)(1));
			w1.RightAttach = ((uint)(2));
			w1.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.gitHubUserNameEntry = new global::Gtk.Entry();
			this.gitHubUserNameEntry.CanFocus = true;
			this.gitHubUserNameEntry.Name = "gitHubUserNameEntry";
			this.gitHubUserNameEntry.IsEditable = true;
			this.gitHubUserNameEntry.InvisibleChar = '●';
			this.table1.Add(this.gitHubUserNameEntry);
			global::Gtk.Table.TableChild w2 = ((global::Gtk.Table.TableChild)(this.table1[this.gitHubUserNameEntry]));
			w2.LeftAttach = ((uint)(1));
			w2.RightAttach = ((uint)(2));
			w2.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label1 = new global::Gtk.Label();
			this.label1.Name = "label1";
			this.label1.Xalign = 0F;
			this.label1.LabelProp = "GitHub User Name:";
			this.table1.Add(this.label1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table1[this.label1]));
			w3.XOptions = ((global::Gtk.AttachOptions)(4));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table1.Gtk.Table+TableChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.Xalign = 0F;
			this.label2.LabelProp = "Gist Personal Access Token:";
			this.table1.Add(this.label2);
			global::Gtk.Table.TableChild w4 = ((global::Gtk.Table.TableChild)(this.table1[this.label2]));
			w4.TopAttach = ((uint)(1));
			w4.BottomAttach = ((uint)(2));
			w4.XOptions = ((global::Gtk.AttachOptions)(4));
			w4.YOptions = ((global::Gtk.AttachOptions)(4));
			this.Add(this.table1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.Hide();
		}
	}
}
