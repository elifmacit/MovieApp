using Microsoft.AspNetCore.Identity;
using MovieApp.Data.DTOs.Generics;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.DTOs.Reviews
{
    public class ReviewDTO:AuditedBaseDTO
    {
        public IdentityUser Reviewer { get; set; }
        public Guid ReviewerId { get; set; }
        public string MovieId { get; set; }
        public string? Comment { get; set; }
        [Range(1, 10)]
        public int Rate { get; set; }
    }
}
