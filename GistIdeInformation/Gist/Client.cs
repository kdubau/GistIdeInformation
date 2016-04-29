using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GistIdeInformation
{
	
	public class GistClient : IDisposable
	{
		public static string GistAuth
		{
			get
			{
				return Convert.ToBase64String(Encoding.Default.GetBytes(
					String.Format("{0}:{1}", GistUserName, GIT_GIST_TOKEN)));
			}
		}
		const string GIT_GIST_TOKEN = "";
		const string GistUserName = "";


		const string API_URL = "https://api.github.com/gists";
		WebClient client;

		readonly string[] illegalChars = new[] { "©", "™", "®", "├", "⌐", "è", "é", "Ê" };

		public GistClient()
		{
			client = new WebClient();
			client.Headers[HttpRequestHeader.UserAgent] = GistUserName;
			client.Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}", GistAuth);
		}

		public static string UploadGist(string gistContent)
		{

			using (var gc = new GistClient())
			{
				return gc.CreateGist(gistContent);
			}
		}

		public string CreateGist(string gistContent)
		{
			return CreateGist("Gist", false, new Dictionary<string, string> {
				{ "file", gistContent }
			});
		}

		public string CreateGist(string gistName, string gistContent)
		{
			return CreateGist("Gist", false, new Dictionary<string, string> {
				{ gistName, gistContent }
			});
		}

		public string CreateGist(string description, string gistName, string gistContent)
		{
			return CreateGist(description, false, new Dictionary<string, string> {
				{ gistName, gistContent }
			});
		}

		public string CreateGist(Dictionary<string, string> logFiles)
		{
			return CreateGist("Gist", false, logFiles);
		}

		public string CreateGist(string description, Dictionary<string, string> logFiles)
		{
			return CreateGist(description, false, logFiles);
		}

		string CreateGist(string description, bool isPublic, Dictionary<string, string> logFiles)
		{
			var files = new Dictionary<string, GistFile>();
			foreach (var log in logFiles)
			{
				// Encountered some logs which failed to post due to illegal content/encoding.
				// This seems to fix the issue, by encoding all gist content in UTF8 before stripping illegal characters.
				string utf8LogValue = Encoding.UTF8.GetString(Encoding.Default.GetBytes(log.Value));
				var newValue = illegalChars.Aggregate(utf8LogValue, (current, c) => current.Replace(c, string.Empty));

				files.Add(log.Key, new GistFile
				{
					Content = newValue
				});
			}
			var gist = new Gist
			{
				Description = description,
				Public = isPublic,
				Files = files
			};

			string gistToJson = JsonConvert.SerializeObject(gist, Formatting.Indented);
			string uploadResult = client.UploadString(API_URL, gistToJson);
			var deserializedContainer = (JContainer)JsonConvert.DeserializeObject(uploadResult);
			var htmlProperty = (JProperty)deserializedContainer.FirstOrDefault(c => ((JProperty)c).Name == "html_url");

			return htmlProperty.Value.ToString();
		}

		public void Dispose()
		{
			client.Dispose();
		}
	}

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

