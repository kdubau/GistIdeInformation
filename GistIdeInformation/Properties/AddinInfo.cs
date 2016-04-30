using System;
using Mono.Addins;
using Mono.Addins.Description;

[assembly: Addin(
	"GistIdeInformation",
	Namespace = "GistIdeInformation",
	Version = "1.0"
)]

[assembly: AddinName("GistIdeInformation")]
[assembly: AddinCategory("IDE extensions")]
[assembly: AddinDescription("Adds a Help command to create a Gist with the IDE information and IDE log file.")]
[assembly: AddinAuthor("Kyle White")]

