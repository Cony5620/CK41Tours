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
        private ITMRepository _tMRepository;
        public ITMRepository TMRepository
        {
            get
            {
                return _tMRepository=_tMRepository ?? new TMRepository(_dbContext);
            }
        }

        #region TT
        private ITTRepository _TTRepository;
        public ITTRepository TTRepository
        {
            get
            {
                return _TTRepository = _TTRepository ?? new TTRepository(_dbContext);
            }
        }
        #endregion

        #region Commit
        public void Commit()
        {
          _dbContext.SaveChanges();
        }
        #endregion

        #region RollBack
        public void RollBack()
        {
          _dbContext.Dispose();
        }
        #endregion
    }
}
