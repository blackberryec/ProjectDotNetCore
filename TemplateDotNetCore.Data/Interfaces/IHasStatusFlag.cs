namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IHasStatusFlag
    {
        bool? HomeFlag { get; set; }

        bool? HotFlag { get; set; }

        bool? NewFlag { get; set; }
    }
}