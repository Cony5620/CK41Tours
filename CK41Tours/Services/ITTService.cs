using CK41Tours.Models.ViewModels;

namespace CK41Tours.Services
{
    public interface ITTService
    {
        void Create(TTViewModel TTViewModel,string photoUrl);
        IEnumerable<TTViewModel> GetAll();
        TTViewModel GetBy(string Id);
        void Update(TTViewModel TTViewModel, string photoUrl);
        bool Delete(string Id);
        IEnumerable<TTViewModel> GetTT();
    }
}
