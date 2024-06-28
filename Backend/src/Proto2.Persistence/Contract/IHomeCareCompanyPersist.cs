using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Domain;

namespace Proto2.Persistence.Contract
{
    public interface IHomeCareCompanyPersist : IGeneralPersist	
    {
        Task<List<HomeCareCompany>> GetHomeCaresAsync();
        Task<HomeCareCompany> GetHomeCareCompanyByIdAsync(int id);        
    }
}