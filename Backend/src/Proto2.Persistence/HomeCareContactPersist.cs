using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Persistence.Contract;
using Proto2.Persistence.Context;
using Proto2.Domain;
using Microsoft.EntityFrameworkCore;

namespace Proto2.Persistence
{
    public class HomeCareContactPersist : GeneralPersist, IHomeCareContactsPersist
    {
        private readonly AppDbContext context;
        public HomeCareContactPersist(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<HomeCareContact> GetHomeCareContactByIDAsync(int id)
        {
            return await context.HomeCareContacts.SingleOrDefaultAsync(h => h.Id == id);
        }

        public async Task<List<HomeCareContact>> GetHomeCareContactsAsync(int homeCareCompanyId)
        {
            var query = context.HomeCareContacts.Where(contacts => contacts.HomeCareCompanyId == homeCareCompanyId);
            return await query.AsNoTracking().ToListAsync();
        }
    }
}