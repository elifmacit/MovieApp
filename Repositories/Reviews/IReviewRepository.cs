using MovieApp.Data.Reviews;
using MovieApp.Repositories.Generics;

namespace MovieApp.Repositories.Reviews
{
    public interface IReviewRepository:IRepository<Review>
    {
        Task<double> GetRatingByMovieId(string movieId);
    }
}
