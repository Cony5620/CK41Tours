using CK41Tours.DAO;
using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.Repositories.Common;

namespace CK41Tours.Repositories.Domain
{
    public class TGRepository : BaseRepository<TGEntity>,ITGRepository
    {
        private readonly CK41ToursDbContext _dbContext;

        public TGRepository(CK41ToursDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TGViewModel> GetTG()
        {
           return _dbContext.TGs.Where(w=>!w.IsInActive).Select(s=>new TGViewModel
           {    Id=s.Id,
                TG01=s.TG01,

           }).ToList();
        }
    }
}
