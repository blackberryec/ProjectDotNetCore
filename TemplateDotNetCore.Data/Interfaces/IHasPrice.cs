namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IHasPrice
    {
        decimal Price { get; set; } 

        decimal? PromotionPrice { get; set; }

        string Unit { get; set; }

    }
}