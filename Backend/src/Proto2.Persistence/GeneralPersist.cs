using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proto2.Persistence.Context;
using Proto2.Persistence.Contract;

namespace Proto2.Persistence;

public class GeneralPersist : IGeneralPersist
{
    private readonly AppDbContext context;

    public GeneralPersist(AppDbContext context){
        this.context = context;
    }
    public void Delete<T>(T entity) where T : class
    {
        context.Remove<T>(entity);
    }

    public void DeleteRange<T>(T entities) where T : class
    {
        context.RemoveRange(entities);
    }

    public async void Insert<T>(T entity) where T : class
    {
        await context.AddAsync<T>(entity);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return (await context.SaveChangesAsync()) > 0;
    }

    public void Update<T>(T entity) where T : class
    {
        context.Update<T>(entity);
    }
}
