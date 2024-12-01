using Microsoft.AspNetCore.Identity;
using MovieApp.Data.Generics;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.Reviews
{
    public class Review:AuditedBaseModel
    {
        public IdentityUser Reviewer { get; set;}
        public string ReviewerId { get; set;}
        public string MovieId { get;set;}
        public string? Comment { get; set; }
        [Range(1, 10)]
        public int Rate { get; set; }

    }
}
