using System.Collections.Generic;
using System.Linq;
using AzureDay.WebApp.Database.Entities;

namespace AzureDay.WebApp.Database.Services
{
    public abstract class BaseService<T, K> where T : BaseEntity<K>
    {
        private List<T> _storage;
        protected List<T> Storage => _storage ?? (_storage = PopulateStorage());

        protected abstract List<T> PopulateStorage();

        public IEnumerable<T> GetAll()
        {
            return Storage;
        }

        public T GetById(K id)
        {
            return Storage.FirstOrDefault(x => x.Id.Equals(id));
        }
    }
}