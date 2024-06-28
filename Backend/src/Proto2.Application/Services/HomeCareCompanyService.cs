using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Application.Contracts;
using Proto2.Application.DTOs;
using Proto2.Persistence.Contract;
using AutoMapper;
using Proto2.Domain;

namespace Proto2.Application.Services
{
    public class HomeCareCompanyService : IHomeCareCompanyService
    {
        private readonly IHomeCareCompanyPersist homeCareCompanyPersist;
        private readonly IMapper mapper;

        private readonly IHomeCareContactsPersist contactsPersist;
        public HomeCareCompanyService(IHomeCareCompanyPersist homeCareCompanyPersist, IHomeCareContactsPersist contactsPersist, IMapper mapper)   
        {
            this.mapper = mapper;
            this.homeCareCompanyPersist = homeCareCompanyPersist;
            this.contactsPersist = contactsPersist;
        }

        public async Task<bool> DeleteHomeCareCompanyByIdAsync(int id)
        {
            try
            {
                var homeCareCompany = await homeCareCompanyPersist.GetHomeCareCompanyByIdAsync(id);
                if (homeCareCompany == null) return false;

                homeCareCompanyPersist.Delete(homeCareCompany);
                if (await homeCareCompanyPersist.SaveChangesAsync()){
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {                
                throw new Exception($"Error while trying to delete de home care company entry. Error: {ex.Message}");
            }
        }

        public async Task<List<HomeCareContactsDTO>> DeleteContactByIdAsync(int homeCareCompanyId, int contactId){
            try
            {
                var contact = await contactsPersist.GetHomeCareContactByIDAsync(contactId);
                if (contact == null) return null;

                if (contact.HomeCareCompanyId == homeCareCompanyId){
                    contactsPersist.Delete(contact);

                    if (await contactsPersist.SaveChangesAsync()){
                        return mapper.Map<List<HomeCareContactsDTO>>(await contactsPersist.GetHomeCareContactsAsync(homeCareCompanyId));
                    }
                } 
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception($"Error while trying to delete the Home Care Contact. Error: ${ex.Message}", ex);
            }
        }

        public async Task<List<HomeCareCompanyDTO>> GetHomeCareCompanies()
        {
            try
            {
                var HomeCareCompanies = await homeCareCompanyPersist.GetHomeCaresAsync();
                var result = mapper.Map<List<HomeCareCompanyDTO>>(HomeCareCompanies);

                return result;

            }
            catch (Exception ex)
            {                
                throw new Exception("Error while trying to retrieve Home Care Companies " + ex.Message);
            }
        }

        public async Task<HomeCareCompanyDTO> GetHomeCareCompanyByIDAsync(int id)
        {
            try
            {
                var homeCareCompany = await homeCareCompanyPersist.GetHomeCareCompanyByIdAsync(id);
                return mapper.Map<HomeCareCompanyDTO>(homeCareCompany);
            }
            catch (Exception ex)
            {                
                throw new Exception("Error while trying to retrieve the Home Care Company. Error: " + ex.Message);
            }
        }

        public async Task<HomeCareContactsDTO> GetHomeCareContactsByIDAsync(int id)
        {
            try
            {
                return mapper.Map<HomeCareContactsDTO>(await contactsPersist.GetHomeCareContactByIDAsync(id));
            }
            catch (Exception ex)
            {                
                throw new Exception($"Error while trying to get the contact data. Error: {ex.Message}");
            }
        }

        public async Task<HomeCareCompanyDTO> Save(HomeCareCompanyDTO homeCareCompanyDTO)
        {
            try
            {
                HomeCareCompany homeCareCompany = mapper.Map<HomeCareCompany>(homeCareCompanyDTO);

                if (homeCareCompany.Id == 0){
                    homeCareCompanyPersist.Insert(homeCareCompany);
                } else {
                    homeCareCompanyPersist.Update(homeCareCompany);
                }
                if (await homeCareCompanyPersist.SaveChangesAsync()){
                    return mapper.Map<HomeCareCompanyDTO>(homeCareCompany);
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception("Error while trying to save. Error: " + ex.Message);
            }
        }

        public async Task<List<HomeCareContactsDTO>> SaveContacts(int homeCareCompanyId,List<HomeCareContactsDTO> contactsList)
        {
            try
            {
                foreach (HomeCareContactsDTO homeCareContactsDTO in contactsList){
                    var homeCareContact = mapper.Map<HomeCareContactsDTO>(homeCareContactsDTO);
                    if (homeCareContact.HomeCareCompanyId == 0) homeCareContact.HomeCareCompanyId = homeCareCompanyId;

                    if (homeCareContact.Id == 0){
                        contactsPersist.Insert(homeCareContact);
                    } else {
                        contactsPersist.Update(homeCareContact); 
                    }                   
                }
                if (await contactsPersist.SaveChangesAsync()){
                    return mapper.Map<List<HomeCareContactsDTO>>(await contactsPersist.GetHomeCareContactsAsync(homeCareCompanyId));
                }
                return null;

            }
            catch (Exception ex)
            {                
                throw new Exception("There was an error while trying to save the contact. Error: " + ex.Message);
            }                      

        }
    }
}