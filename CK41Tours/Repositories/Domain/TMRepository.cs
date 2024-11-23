using CK41Tours.DAO;
using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.Repositories.Common;

namespace CK41Tours.Repositories.Domain
{
    public class TMRepository : BaseRepository<TMEntity>,ITMRepository
    {
        private readonly CK41ToursDbContext _dbContext;

        public TMRepository(CK41ToursDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public IEnumerable<TMViewModel> GetTM()
        {
            return _dbContext.TMEs.Where(w => !w.IsInActive).Select(s => new TMViewModel
            {
                Id = s.Id,
               TM01 = s.TM01,
            }).ToList();
        }
    }
}
