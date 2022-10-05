using Pastels.Api.Resources;
using Pastels.Application.Repositories;

namespace Pastels.Application
{
    public class PastelService : IPastelService
    {
        private readonly IPastelRepository pastelRepository;

        public PastelService(IPastelRepository pastelRepository)
        {
            this.pastelRepository = pastelRepository;
        }

        public async Task<IEnumerable<Pastel>> FindAll()
        {
            return await pastelRepository.FindAll();
            //var a= Enumerable.Range(1, 5).Select(index => new Pastel
            //{
            //    Name = "Pastel" + index,
            //    Ingredients = new List<string>() { "Ingredient" + index, "Ingredient" + index * 2 }
            //}).ToArray();
            //return await Task.FromResult(a);
        }
    }
}