using CK41Tours.Models.ViewModels;

namespace CK41Tours.Services
{
    public interface ITMService
    {
        void Create(TMViewModel TMViewModel,string photoUrl);
        IEnumerable<TMViewModel> GetAll();
        TMViewModel GettBy(string Id);
        void Update(TMViewModel TMViewModel, string photoUrl);
        bool Delete(string Id);
        IEnumerable<TMViewModel> GetTM();
    }
}
