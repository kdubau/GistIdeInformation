using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"GistIdeInformation",
	Namespace = "GistIdeInformation",
	Version = "1.0.3"
)]

[assembly: AddinName("Gist Ide Information")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("Adds a Help command to create a Gist with the IDE information and IDE log files. Requires a GitHub personal access token with Gist permission.\n\nThis is very useful for reporting bugs!\nhttps://bugzilla.xamarin.com/")]
[assembly: AddinAuthor("Kyle White")]
[assembly: AddinUrl("https://github.com/kdubau/GistIdeInformation")]


