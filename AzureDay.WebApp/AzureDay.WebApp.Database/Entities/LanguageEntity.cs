namespace AzureDay.WebApp.Database.Entities
{
    public class LanguageEntity: BaseEntity<string>
    {
        public string Title { get; set; }
        public string FlagUrl { get; set; }
    }
}