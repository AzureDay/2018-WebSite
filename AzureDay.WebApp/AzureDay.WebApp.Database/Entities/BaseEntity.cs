namespace AzureDay.WebApp.Database.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}