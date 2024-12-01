using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieApp.Data.DTOs.Reviews;
using MovieApp.Data.External.Movies;
using MovieApp.Data.Reviews;
using MovieApp.Repositories.Reviews;

namespace MovieApp.Services.Reviews
{
    public class ReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<List<ReviewDTO>> GetAllReviewsAsync()
        {
            return _mapper.Map<List<ReviewDTO>>(await _reviewRepository.GetAll().ToListAsync());
        }

        public async Task<List<string>> GetMostRatedNMovieIdsAsync(int take=10)
        {
            var topRatedMovies = await _reviewRepository.GetAll()
                .GroupBy(x => x.MovieId)
                .Select(g => new
                {
                    MovieId = g.Key,
                    AverageRate = g.Average(x => x.Rate)
                })
                .OrderByDescending(x => x.AverageRate)
                .Take(take)
                .ToListAsync();

            return topRatedMovies.Select(x => x.MovieId).ToList();

        }

        public async Task<List<ReviewDTO>> GetReviewsByMovieIdAsync(string movieId)
        {
            return _mapper.Map<List<ReviewDTO>>(await _reviewRepository.GetAll().Where(x => x.MovieId == movieId).ToListAsync());
        }



        public async Task<ReviewDTO> GetReviewByIdAsync(Guid id)
        {
            return _mapper.Map<ReviewDTO>(await _reviewRepository.GetByIdAsync(id));
        }

        public async Task AddReviewAsync(ReviewCUDTO dto)
        {
            await _reviewRepository.AddAsync(_mapper.Map<Review>(dto));
        }

        public async Task UpdateReviewAsync(ReviewCUDTO dto)
        {
            await _reviewRepository.UpdateAsync(_mapper.Map<Review>(dto));
        }

        public async Task DeleteReviewAsync(Guid id)
        {
            await _reviewRepository.DeleteAsync(id);
        }

        public async Task<double> GetRatingByMovieId(string movieId)
        {
            return await _reviewRepository.GetRatingByMovieId(movieId);
        }
    }
}
