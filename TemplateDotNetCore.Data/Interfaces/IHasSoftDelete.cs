namespace TemplateDotNetCore.Data.Interfaces
{
    public interface IHasSoftDelete
    {
        bool isDeleted { get; set; }
    }
}