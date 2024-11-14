using CK41Tours.DAO;
using CK41Tours.Models.DataModels;
using CK41Tours.Repositories.Common;

namespace CK41Tours.Repositories.Domain
{
    public class DTRepository : BaseRepository<DTEntity>, IDTRepository
    {
        private readonly CK41ToursDbContext _dbContext;

        public DTRepository(CK41ToursDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

       
    }
}
