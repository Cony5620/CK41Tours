﻿using CK41Tours.Models.DataModels;
using CK41Tours.Models.ViewModels;
using CK41Tours.Repositories.Common;

namespace CK41Tours.Repositories.Domain
{
    public interface ITGRepository:IBaseRepository<TGEntity>
    {
        IEnumerable<TGViewModel> GetTG();
    }
}
