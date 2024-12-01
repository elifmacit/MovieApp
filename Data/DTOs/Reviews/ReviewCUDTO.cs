using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MovieApp.Data.DTOs.Reviews
{
    public class ReviewCUDTO
    {
        public Guid ReviewerId { get; set; }
        public string MovieId { get; set; }
        public string? Comment { get; set; }
        [Range(1, 10)]
        public int Rate { get; set; }
    }
}
