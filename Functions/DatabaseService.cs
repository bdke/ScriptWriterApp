using Microsoft.EntityFrameworkCore;
using ScriptWriterApp.Data;
using ScriptWriterApp.IData;

namespace ScriptWriterApp.Functions
{

    public class DatabaseAccessService<T> where T : IDatabaseData
    {
        protected AppDbContext dbContext;

        public DatabaseAccessService(AppDbContext context)
        {
            dbContext = context;
        }

        public virtual Task<bool> AddValueAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> DeleteValueAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public virtual Task<List<T>> GetValueAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> UpdateValueAsync(T obj)
        {
            throw new NotImplementedException();
        }
    }

    public class ChangeHistoryAccessService : DatabaseAccessService<ChangeHistory>
    {
        public ChangeHistoryAccessService(AppDbContext context) : base(context) { }

        public override async Task<List<ChangeHistory>> GetValueAsync()
        {
            return await dbContext.ChangeHistories.ToListAsync();
        }

        public override async Task<bool> AddValueAsync(ChangeHistory obj)
        {
            try
            {
                dbContext.ChangeHistories.Add(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> UpdateValueAsync(ChangeHistory obj)
        {
            try
            {
                var Exist = dbContext.ChangeHistories.FirstOrDefault(x => x.ID == obj.ID);
                if (Exist != null)
                {
                    dbContext.Update(obj);
                    await dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> DeleteValueAsync(ChangeHistory obj)
        {
            try
            {
                dbContext.ChangeHistories.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
