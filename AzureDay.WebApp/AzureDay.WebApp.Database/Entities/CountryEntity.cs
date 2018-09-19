namespace AzureDay.WebApp.Database.Entities
{
    public class CountryEntity: BaseEntity<int>
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}