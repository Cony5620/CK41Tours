using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.UnitOfWorks;

namespace CK41Tours.Services
{
    public class DDService :IDDService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DDService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public void Create(DDViewModel DDViewModel,string photoUrl,string gallery1Url, string gallery2Url)
        {
            DDEntity DDEntity= new DDEntity()
            {
                Id=Guid.NewGuid().ToString(),
                DD01=DDViewModel.DD01,
                DD02=DDViewModel.DD02,
                DD03 =photoUrl,
                DD04=DDViewModel.DD04,
                DD05=DDViewModel.DD05,
                DD06=DDViewModel.DD06,
                DD07=DDViewModel.DD07,
                DD08= gallery1Url,
                DD09= gallery2Url,
                DD10=DDViewModel.DD10,
                DD11=DDViewModel.DD11,
                CreatedAt =DateTime.Now,
            };
            _unitOfWork.DDRepository.Create(DDEntity);
            _unitOfWork.Commit(); 
        }

        public bool Delete(string Id)
        {
            try
            {
                DDEntity DDEntity = _unitOfWork.DDRepository.GetBy(w => w.Id == Id).SingleOrDefault();
                if (DDEntity != null)
                {
                    DDEntity.IsInActive = true;
                    _unitOfWork.DDRepository.Update(DDEntity);
                    _unitOfWork.Commit();
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public IEnumerable<DDViewModel> GetAll()
        {
            IEnumerable<DDViewModel> DD = from dd in _unitOfWork.DDRepository.GetAll()
                                          join TT in _unitOfWork.TTRepository.GetAll()
                                          on dd.DD11 equals TT.Id
                                          join TM in _unitOfWork.TMRepository.GetAll()
                                          on dd.DD10 equals TM.Id
                                          join TG in _unitOfWork.TGRepository.GetAll()
                                          on dd.DD07 equals TG.Id
                                          join dT in _unitOfWork.DTRepository.GetAll()
                                          on dd.DD01 equals dT.Id
                                          where !dd.IsInActive && !TT.IsInActive && !TM.IsInActive && !TG.IsInActive && !dT.IsInActive
                                          select new DDViewModel
                                          {     Id=dd.Id,
                                              DD01 = dT.DT01,
                                              DD02 = dd.DD02,
                                              DD03 = dd.DD03,
                                              DD04 = dd.DD04,
                                              DD05 = dd.DD05,
                                              DD06 = dd.DD06,
                                              DD07 = TG.TG01,
                                              DD08 = dd.DD08,
                                              DD09 = dd.DD09,
                                              DD10 = TM.TM01,
                                              DD11 = TT.TT01
                                          };

            return DD;
        }

        public DDViewModel GettBy(string Id)
        {
            return _unitOfWork.DDRepository.GetBy(w => w.Id == Id && !w.IsInActive).Select(s => new DDViewModel
                {    Id=s.Id,
                     DD01=s.DD01,
                    DD02=s.DD02,
                    DD03=s.DD03,
                    DD04=s.DD04,
                    DD05=s.DD05,
                    DD06=s.DD06,
                    DD07=s.DD07,
                    DD08=s.DD08,
                    DD09=s.DD09,
                    DD10=s.DD10,
                    DD11=s.DD11,
            
            }).FirstOrDefault();

            
            }
        public void Update(DDViewModel DDViewModel, string photoUrl, string gallery1Url, string gallery2Url)
        {
            
            var existingDDEntity = _unitOfWork.DDRepository.GetBy(w => w.Id == DDViewModel.Id).FirstOrDefault();

            if (existingDDEntity == null)
            {
                throw new Exception("Destination Detail not found.");
            }

            existingDDEntity.Id = DDViewModel.Id;
            existingDDEntity.DD01 = DDViewModel.DD01; 
            existingDDEntity.DD02 = DDViewModel.DD02; 
            existingDDEntity.DD03 = string.IsNullOrEmpty(photoUrl) ? existingDDEntity.DD03 : photoUrl; 
            existingDDEntity.DD04 = DDViewModel.DD04; 
            existingDDEntity.DD05 = DDViewModel.DD05; 
            existingDDEntity.DD06 = DDViewModel.DD06; 
            existingDDEntity.DD07 = DDViewModel.DD07; 
            existingDDEntity.DD08 = string.IsNullOrEmpty(gallery1Url) ? existingDDEntity.DD08 : gallery1Url; 
            existingDDEntity.DD09 = string.IsNullOrEmpty(gallery2Url) ? existingDDEntity.DD09 : gallery2Url; 
            existingDDEntity.DD10 = DDViewModel.DD10; 
            existingDDEntity.DD11 = DDViewModel.DD11; 

           
            existingDDEntity.ModifiedAt = DateTime.Now;

           
            _unitOfWork.DDRepository.Update(existingDDEntity);
            _unitOfWork.Commit();
        }
    }

}
