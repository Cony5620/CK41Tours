using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.UnitOfWorks;
///ammt 20241117
namespace CK41Tours.Services
{
    public class TTService : ITTService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TTService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(TTViewModel TTViewModel,string photoUrl)
        {
            TTEntity TTEntity= new TTEntity()
            {
                Id=Guid.NewGuid().ToString(),
                TT01=TTViewModel.TT01,
                TT02=TTViewModel.TT02,
                TT03 =photoUrl,
                CreatedAt =DateTime.Now,
            };
            _unitOfWork.TTRepository.Create(TTEntity);
            _unitOfWork.Commit(); 
        }

        public bool Delete(string Id)
        {
            try
            {
                TTEntity TTEntity = _unitOfWork.TTRepository.GetBy(w => w.Id == Id).FirstOrDefault();
                if (TTEntity != null)
                {
                    TTEntity.IsInActive = true;
                    _unitOfWork.TTRepository.Update(TTEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<TTViewModel> GetAll()
        {
           return _unitOfWork.TTRepository.GetAll().Where(w=>!w.IsInActive).Select(s=>new TTViewModel
           {    Id=s.Id,
              TT01=s.TT01,
              TT02=s.TT02,
               TT03 = s.TT03,
           }).AsEnumerable();
        }

        public TTViewModel GetBy(string Id)
        {
            return _unitOfWork.TTRepository.GetBy(w=>w.Id==Id && !w.IsInActive).Select(s=>new TTViewModel
            {
                Id = s.Id,
                TT01 = s.TT01,
                TT02 = s.TT02,
                TT03 = s.TT03,
            }).FirstOrDefault();
        }

        public void Update(TTViewModel TTViewModel,string photoUrl)
        {
            TTEntity TTEntity = new TTEntity()
            {
                Id = TTViewModel.Id,
                TT01 = TTViewModel.TT01,
                TT02 = TTViewModel.TT02,
                TT03 = photoUrl,
              ModifiedAt=DateTime.Now,
            };
            _unitOfWork.TTRepository.Update(TTEntity);
            _unitOfWork.Commit();
        }
    }
}
