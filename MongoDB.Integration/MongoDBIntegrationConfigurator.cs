using Labelling.Persistence.DataStores;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace MongoDB.Integration
{
	public static class MongoDBIntegrationConfigurator
	{
		public static void AddMongoDBIntegration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddSingleton(new MongoClient(configuration.GetConnectionString("Mongo")));
			services.AddSingleton(new MongoDatabaseName(configuration.GetValue<string>("MongoDatabaseName")));
			services.AddSingleton<IIdGenerator>(new ObjectIdGenerator());
			services.AddTransient<IPurchaseOrderDataStore, ProductOrderDataStore>();
			services.AddTransient<IItemRegistrationDataStore, ItemRegistrationDataStore>();
			services.AddTransient<IPrintHistoryLogDataStore, PrintHistoryLogDataStore>();
			services.AddTransient<ILabelFavoritesDataStore, LabelFavoritesDataStore>();
			services.AddTransient<ILabelTemplateDataStore, LabelTemplateDataStore>();
			services.AddTransient<IRegistryItemDataStore, PastelDataStore>();
		}
	}
}