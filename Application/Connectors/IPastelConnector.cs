using Application.Model;

namespace Application.Connectors
{
    public interface IPastelConnector
    {
        Task<IList<Pastel>> FindAll();
    }
}
