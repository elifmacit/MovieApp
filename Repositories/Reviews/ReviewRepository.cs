using Microsoft.EntityFrameworkCore;
using MovieApp.Data;
using MovieApp.Data.Reviews;
using MovieApp.Repositories.Generics;

namespace MovieApp.Repositories.Reviews
{
    public class ReviewRepository : GenericRepository<Review>, IReviewRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<double> GetRatingByMovieId(string movieId)
        {
            return await _dbContext.Set<Review>().Where(x=>x.MovieId == movieId).AverageAsync(x=>x.Rate);
        }

    }
}
