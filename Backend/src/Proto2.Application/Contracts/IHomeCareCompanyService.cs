using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Application.DTOs;

namespace Proto2.Application.Contracts
{
    public interface IHomeCareCompanyService
    {
        Task<HomeCareCompanyDTO> GetHomeCareCompanyByIDAsync(int id);
        Task<List<HomeCareCompanyDTO>> GetHomeCareCompanies();
        Task<HomeCareCompanyDTO> Save(HomeCareCompanyDTO homeCareCompanyDTO);
        Task<bool> DeleteHomeCareCompanyByIdAsync(int id);
        Task<HomeCareContactsDTO> GetHomeCareContactsByIDAsync(int id);        
        Task<List<HomeCareContactsDTO>> DeleteContactByIdAsync(int homeCareCompanyId, int contactId);
        Task<List<HomeCareContactsDTO>> SaveContacts(int homeCareCompanyId, List<HomeCareContactsDTO> contactsList);
    }
}