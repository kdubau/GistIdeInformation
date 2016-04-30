using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GistIdeInformation
{
	class Gist
	{
		[JsonProperty(PropertyName = "description")]
		public string Description { get; set; }

		[JsonProperty(PropertyName = "public")]
		public bool Public { get; set; }

		[JsonProperty(PropertyName = "files")]
		public Dictionary<string, GistFile> Files { get; set; }
	}

	class GistFile
	{
		[JsonProperty(PropertyName = "content")]
		public string Content { get; set; }
	}
}

