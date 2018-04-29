using System;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace githubpanviva.Models
                       
{
    public class GitHubRequestHandler
    {
        public JToken GetReleases(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                var response = httpClient.GetStringAsync(new Uri(url)).Result;

                return JArray.Parse(response);
            }
        }


        public GitHubProfile GetReleases1(string url)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");

                var response = httpClient.GetStringAsync(new Uri(url)).Result;
                GitHubProfile profile = JsonConvert.DeserializeObject<GitHubProfile>(response);

                return profile;

            }
        }
    }
}
