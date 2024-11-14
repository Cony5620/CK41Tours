using CK41Tours.Models.ViewModels;

namespace CK41Tours.Services
{
    public interface IDTService
    {
        void Create(DTViewModel DTViewModel,string photoUrl);
        IEnumerable<DTViewModel> GetAll();
        DTViewModel GettBy(string Id);
        void Update(DTViewModel DTViewModel, string photoUrl);
        bool Delete(string Id);
    }
}
