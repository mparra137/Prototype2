using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Domain;

namespace Proto2.Persistence.Contract
{
    public interface IHomeCareContactsPersist: IGeneralPersist
    {
        Task<List<HomeCareContact>> GetHomeCareContactsAsync(int homeCareCompanyId);
        Task<HomeCareContact> GetHomeCareContactByIDAsync(int id);
    }
}