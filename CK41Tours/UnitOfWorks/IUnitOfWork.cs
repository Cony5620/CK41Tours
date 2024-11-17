using CK41Tours.Repositories.Domain;

namespace CK41Tours.UnitOfWorks
{
    public interface IUnitOfWork
    {  ITGRepository TGRepository { get; }
        IDTRepository DTRepository { get; } 
        ITMRepository TMRepository { get; }
        void Commit();
        void RollBack();
    }
}
