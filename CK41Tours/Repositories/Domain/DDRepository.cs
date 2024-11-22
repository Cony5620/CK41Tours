using CK41Tours.DAO;
using CK41Tours.Models.DataModels;
using CK41Tours.Repositories.Common;

namespace CK41Tours.Repositories.Domain
{
    public class DDRepository : BaseRepository<DDEntity>, IDDRepository
    {
        public DDRepository(CK41ToursDbContext dbContext) : base(dbContext)
        {
        }
    }
}
