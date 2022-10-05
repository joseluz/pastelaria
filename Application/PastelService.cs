using Application.Connectors;
using Application.Model;

namespace Application
{
    public class PastelService: IPastelService
    {
        private readonly IPastelConnector pastelConnector;

        public PastelService(IPastelConnector pastelConnector)
        {
            this.pastelConnector = pastelConnector;
        }

        public async Task<IList<Pastel>> FindAll()
        {
            return await pastelConnector.FindAll();
        }
    }
}