using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using githubpanviva.Models;
using Newtonsoft.Json.Linq;
using System.Net;
using Newtonsoft.Json;

namespace github_panviva.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Search(String userName)
        {
            List<GitHubRepo> repoList = new List<GitHubRepo>();
            GitHubRepo repo=null;
            try
            {
                if (string.IsNullOrEmpty(userName)) throw new InvalidOperationException("EmptyInput");
                GitHubRequestHandler handler = new GitHubRequestHandler();
                if (!string.IsNullOrWhiteSpace(userName))
                {
                    String url = "https://api.github.com/users/" + userName + "/repos";
                    var releases = handler.GetReleases(url);
                    //List out the retreived releases
                    foreach (JObject release in releases.Children())
                    {
                        Console.WriteLine("name: {0}", release.GetValue("name"));
                        Console.WriteLine("fullname: {0}", release.GetValue("full_name"));
                        Console.WriteLine();
                        repo = JsonConvert.DeserializeObject<GitHubRepo>(release.ToString(Newtonsoft.Json.Formatting.None));
                        repo.git_url = repo.git_url.Substring(6, repo.git_url.Length - 6);
                        repoList.Add(repo);


                    }

                    GitHubProfile profile = handler.GetReleases1("https://api.github.com/users/" + userName);


                    Console.WriteLine("login: {0}", profile.login);
                    Console.WriteLine("name: {0}", profile.name);
                    ViewData["accountName"] = profile.login;
                    ViewData["date"] = DateTime.Parse(profile.updated_at).ToString();
                    ViewData["followers"] = profile.followers;
                    ViewData["following"] = profile.following;

                    return View(repoList);

                }
                else
                {
                    Index();
                }
            }catch(Exception e){}




            return View("404");

        }

        public IActionResult Index()
        {
           

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


    }
}
