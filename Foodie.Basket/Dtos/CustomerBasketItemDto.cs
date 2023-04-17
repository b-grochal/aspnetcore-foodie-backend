namespace Foodie.Basket.API.Dtos
{
    public class CustomerBasketItemDto
    {
        public int Id { get; set; }
        public int MealId { get; set; }
        public string MealName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
