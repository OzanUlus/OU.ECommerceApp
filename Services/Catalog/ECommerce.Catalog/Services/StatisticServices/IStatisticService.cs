namespace ECommerce.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        long GetCategoryCount();
        long GetProductCount();
        long GetBrandCount();
         Task<decimal> GetProductAvgPrice();
    }
}
