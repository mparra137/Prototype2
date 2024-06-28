using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proto2.Domain;
using Proto2.Persistence.Context;
using Proto2.Persistence.Contract;

namespace Proto2.Persistence
{
    public class HomeCareCompanyPersist : GeneralPersist, IHomeCareCompanyPersist
    {
        private readonly AppDbContext context;
        public HomeCareCompanyPersist(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<HomeCareCompany> GetHomeCareCompanyByIdAsync(int id)
        {
            return await context.HomeCareCompanies.Include(c => c.Contacts).SingleOrDefaultAsync(hc => hc.Id == id);   
        }

        public async Task<List<HomeCareCompany>> GetHomeCaresAsync()
        {
            return await context.HomeCareCompanies.ToListAsync();
        }
    }
}