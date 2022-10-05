using Pastels.Api.Resources;
using Pastels.Application.Repositories;
using Pastels.Persistence.DataStores;

namespace Pastels.Persistence
{
    public class PastelRepository : IPastelRepository
    {
        private readonly IPastelDataStore dataStore;

        public PastelRepository(IPastelDataStore dataStore)
        {
            this.dataStore = dataStore;
        }

        public async Task<IEnumerable<Pastel>> FindAll()
        {
            return (await dataStore.FindAll())
                .Select(p => new Pastel() { Name = p.Flavor, Ingredients = p.Ingredients, IsSweet = p.IsSweet });
        }
    }
}
