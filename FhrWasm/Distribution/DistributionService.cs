using FhrWasm.RatingsApi;

namespace FhrWasm.Distribution
{
    public class DistributionService(RatingsApiService api)
    {
        public async Task<Dictionary<string, decimal>> GetRatings(int authorityId)
        {
            var establishments = await api.GetEstablishments(authorityId);
            var totalCount = establishments.Count();
            var groupedByRating = establishments.GroupBy(establishment => establishment.RatingValue);

            return groupedByRating
                .ToDictionary(group => group.Key, group => ((decimal)group.Count()).AsFractionOf(totalCount));
        }
    }
}
