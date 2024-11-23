using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.Repositories.Common;
/// ammt 20241117
namespace CK41Tours.Repositories.Domain
{
    public interface ITTRepository:IBaseRepository<TTEntity>
    {
        IEnumerable<TTViewModel> GetTT();
    }
}
