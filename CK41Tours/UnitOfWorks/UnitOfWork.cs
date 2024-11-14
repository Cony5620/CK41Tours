using CK41Tours.DAO;
using CK41Tours.Repositories.Domain;

namespace CK41Tours.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CK41ToursDbContext _dbContext;

        public UnitOfWork(CK41ToursDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        private ITGRepository _tGRepository;
       
        public ITGRepository TGRepository
        {
            get
            {

            return _tGRepository=_tGRepository?? new TGRepository(_dbContext);}
        }
        private IDTRepository _dTRepository;
        public IDTRepository DTRepository
        {
            get
            {
                return _dTRepository=_dTRepository?? new DTRepository(_dbContext);
            }
        }

        public void Commit()
        {
          _dbContext.SaveChanges();
        }

        public void RollBack()
        {
          _dbContext.Dispose();
        }
    }
}
