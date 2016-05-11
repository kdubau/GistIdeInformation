using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"GistIdeInformation",
	Namespace = "GistIdeInformation",
	Version = "1.0"
)]

[assembly: AddinName("Gist Ide Information")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("Adds a Help command to create a Gist with the IDE information and IDE log files. Please see https://github.com/kdubau/GistIdeInformation for README.md and reporting issues.")]
[assembly: AddinAuthor("Kyle White")]

