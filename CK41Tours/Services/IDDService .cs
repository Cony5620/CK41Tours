using CK41Tours.Models.ViewModels;

namespace CK41Tours.Services
{
    public interface IDDService
    {
        void Create(DDViewModel DDViewModel,string photoUrl,string gallery1Url, string gallery2Url);
        IEnumerable<DDViewModel> GetAll();
        DDViewModel GettBy(string Id);
        void Update(DDViewModel DDViewModel, string photoUrl, string gallery1Url, string gallery2Url);
        bool Delete(string Id);
    
    }
}
