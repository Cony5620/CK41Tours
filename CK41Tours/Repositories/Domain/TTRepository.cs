using CK41Tours.DAO;
using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.Repositories.Common;
/// ammt 20241117
namespace CK41Tours.Repositories.Domain
{
    public class TTRepository : BaseRepository<TTEntity>,ITTRepository
    {
        private readonly CK41ToursDbContext _dbContext;

        public TTRepository(CK41ToursDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TTViewModel> GetTT()
        {
            return _dbContext.TTs.Where(w=>!w.IsInActive).Select(s=>new TTViewModel
            {   Id=s.Id,
                TT01=s.TT01,

            }).ToList();
        }
    }
}
