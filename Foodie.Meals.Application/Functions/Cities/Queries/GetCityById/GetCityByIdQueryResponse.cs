namespace Foodie.Meals.Application.Functions.Cities.Queries.GetCityById
{
    public class GetCityByIdQueryResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}
