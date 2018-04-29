using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace githubpanviva.Models
{
    public class GitHubRepo
    {
        [Display(Name = "Project Name")]
        public string name { get; set; }
        [Display(Name = "Created Date")]
        public String created_at { get; set; }
        [Display(Name = "Project Link")]
        public String git_url { get; set; }

    }
}
