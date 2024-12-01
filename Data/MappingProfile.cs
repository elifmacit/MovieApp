using AutoMapper;
using MovieApp.Data.DTOs.Reviews;
using MovieApp.Data.Reviews;

namespace MovieApp.Data
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            CreateMap<ReviewCUDTO, Review>();
            CreateMap<Review,ReviewDTO>();
        }
    }
}
