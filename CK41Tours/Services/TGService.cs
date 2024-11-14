using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.UnitOfWorks;

namespace CK41Tours.Services
{
    public class TGService : ITGService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TGService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(TGViewModel tGViewModel)
        {
            TGEntity tGEntity= new TGEntity()
            {
                Id=Guid.NewGuid().ToString(),
                TG01=tGViewModel.TG01,
                TG02=tGViewModel.TG02,
                CreatedAt=DateTime.Now,
            };
            _unitOfWork.TGRepository.Create(tGEntity);
            _unitOfWork.Commit(); 
        }

        public bool Delete(string Id)
        {
            try
            {
                TGEntity tGEntity = _unitOfWork.TGRepository.GetBy(w => w.Id == Id).FirstOrDefault();
                if (tGEntity != null)
                {
                    tGEntity.IsInActive = true;
                    _unitOfWork.TGRepository.Update(tGEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<TGViewModel> GetAll()
        {
           return _unitOfWork.TGRepository.GetAll().Where(w=>!w.IsInActive).Select(s=>new TGViewModel
           {    Id=s.Id,
              TG01=s.TG01,
              TG02=s.TG02,
           }).AsEnumerable();
        }

        public TGViewModel GettBy(string Id)
        {
            return _unitOfWork.TGRepository.GetBy(w=>w.Id==Id && !w.IsInActive).Select(s=>new TGViewModel
            {
                Id = s.Id,
                TG01 = s.TG01,
                TG02 = s.TG02,
            }).FirstOrDefault();
        }

        public void Update(TGViewModel tGViewModel)
        {
            TGEntity tGEntity = new TGEntity()
            {
                Id = tGViewModel.Id,
                TG01 = tGViewModel.TG01,
                TG02 = tGViewModel.TG02,
                ModifiedAt = DateTime.Now,
            };
            _unitOfWork.TGRepository.Update(tGEntity);
            _unitOfWork.Commit();
        }
    }
}
