using CK41Tours.Models.ViewModels;

namespace CK41Tours.Services
{
    public interface ITGService
    {
        void Create(TGViewModel tGViewModel);
        IEnumerable<TGViewModel> GetAll();
        TGViewModel GettBy(string Id);
        void Update(TGViewModel tGViewModel);
        bool Delete(string Id);
    }
}
