using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.UnitOfWorks;

namespace CK41Tours.Services
{
    public class TMService : ITMService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TMService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(TMViewModel TMViewModel, string photoUrl)
        {
            TMEntity TMEntity = new TMEntity()
            {
                Id = Guid.NewGuid().ToString(),
                TM01 = TMViewModel.TM01,
                TM02 = photoUrl,
                TM03 = TMViewModel.TM03,
                TM04 = TMViewModel.TM04,
                TM05 = TMViewModel.TM05,
                CreatedAt = DateTime.Now,
            };
            _unitOfWork.TMRepository.Create(TMEntity);
            _unitOfWork.Commit();
        }

        public bool Delete(string Id)
        {
            try
            {
                TMEntity TMEntity = _unitOfWork.TMRepository.GetBy(w => w.Id == Id).FirstOrDefault();
                if (TMEntity != null)
                {
                    TMEntity.IsInActive = true;
                    _unitOfWork.TMRepository.Update(TMEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<TMViewModel> GetAll()
        {
            return _unitOfWork.TMRepository.GetAll().Where(w => !w.IsInActive).Select(s => new TMViewModel
            {
                Id = s.Id,
                TM01 = s.TM01,
                TM02 = s.TM02,
                TM03 = s.TM03,
                TM04 = s.TM04,
                TM05 = s.TM05,
            }).AsEnumerable();
        }

        public TMViewModel GettBy(string Id)
        {
            return _unitOfWork.TMRepository.GetBy(w => w.Id == Id && !w.IsInActive).Select(s => new TMViewModel
            {
                Id = s.Id,
                TM01 = s.TM01,
                TM02 = s.TM02,
                TM03 = s.TM03,
                TM04 = s.TM04,
                TM05 = s.TM05,
            }).FirstOrDefault();
        }

        public void Update(TMViewModel TMViewModel, string photoUrl)
        {
            var existingTMEntity = _unitOfWork.TMRepository.GetBy(w => w.Id == TMViewModel.Id).FirstOrDefault();

            if (existingTMEntity == null)
            {
                throw new Exception("Team member not found.");
            }

            // Update entity fields
            existingTMEntity.TM01 = TMViewModel.TM01;
            existingTMEntity.TM02 = string.IsNullOrEmpty(photoUrl) ? existingTMEntity.TM02 : photoUrl;
            existingTMEntity.TM03 = TMViewModel.TM03;
            existingTMEntity.TM04 = TMViewModel.TM04;
            existingTMEntity.TM05 = TMViewModel.TM05;
            existingTMEntity.ModifiedAt = DateTime.Now;

            _unitOfWork.TMRepository.Update(existingTMEntity);
            _unitOfWork.Commit();
        }
    }
}
