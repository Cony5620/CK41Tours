using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.UnitOfWorks;

namespace CK41Tours.Services
{
    public class DTService : IDTService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DTService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(DTViewModel DTViewModel,string photoUrl)
        {
            DTEntity DTEntity= new DTEntity()
            {
                Id=Guid.NewGuid().ToString(),
                DT01=DTViewModel.DT01,
                DT02=DTViewModel.DT02,
                DT03 =photoUrl,
                CreatedAt =DateTime.Now,
            };
            _unitOfWork.DTRepository.Create(DTEntity);
            _unitOfWork.Commit(); 
        }

        public bool Delete(string Id)
        {
            try
            {
                DTEntity DTEntity = _unitOfWork.DTRepository.GetBy(w => w.Id == Id).FirstOrDefault();
                if (DTEntity != null)
                {
                    DTEntity.IsInActive = true;
                    _unitOfWork.DTRepository.Update(DTEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<DTViewModel> GetAll()
        {
           return _unitOfWork.DTRepository.GetAll().Where(w=>!w.IsInActive).Select(s=>new DTViewModel
           {    Id=s.Id,
              DT01=s.DT01,
              DT02=s.DT02,
               DT03 = s.DT03,
           }).AsEnumerable();
        }

        public DTViewModel GettBy(string Id)
        {
            return _unitOfWork.DTRepository.GetBy(w=>w.Id==Id && !w.IsInActive).Select(s=>new DTViewModel
            {
                Id = s.Id,
                DT01 = s.DT01,
                DT02 = s.DT02,
                DT03 = s.DT03,
            }).FirstOrDefault();
        }

        public void Update(DTViewModel DTViewModel,string photoUrl)
        {
            var existingDTEntity = _unitOfWork.DTRepository.GetBy(w => w.Id == DTViewModel.Id).FirstOrDefault();

            if (existingDTEntity == null)
            {
                throw new Exception(" Destination not found.");
            }

            // Update entity fields
            existingDTEntity.DT01 = DTViewModel.DT01;
            existingDTEntity.DT02 = DTViewModel.DT02;
            existingDTEntity.DT03 = string.IsNullOrEmpty(photoUrl) ? existingDTEntity.DT03 : photoUrl;

            existingDTEntity.ModifiedAt = DateTime.Now;

            _unitOfWork.DTRepository.Update(existingDTEntity);
            _unitOfWork.Commit();
        }
    }
}
