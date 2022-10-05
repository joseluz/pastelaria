using Application.Model;

namespace Application
{
    public interface IPastelService
    {
        Task<IList<Pastel>> FindAll();
    }
}