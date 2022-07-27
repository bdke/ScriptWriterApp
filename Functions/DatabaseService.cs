using Microsoft.EntityFrameworkCore;
using ScriptWriterApp.Data;
using ScriptWriterApp.IData;
using ScriptWriterApp.Functions;

namespace ScriptWriterApp.Functions
{

    public abstract class DatabaseAccessService<T> where T : IDatabaseData
    {
        protected AppDbContext dbContext;
        protected Logging log;

        public DatabaseAccessService(AppDbContext context, ILogger logger)
        {
            dbContext = context;
            this.log = new Logging(logger);
        }

        public abstract Task<bool> AddValueAsync(T obj);

        public abstract Task<bool> DeleteValueAsync(T obj);

        public abstract Task<List<T>> GetValueAsync();

        public abstract Task<bool> UpdateValueAsync(T obj);
    }

    public class ChangeHistoryAccessService : DatabaseAccessService<ChangeHistory>
    {
        public ChangeHistoryAccessService(AppDbContext context, ILogger<ChangeHistoryAccessService> logger) : base(context, logger) { }

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

    public class PagesDataAccessService : DatabaseAccessService<PagesData>
    {
        public PagesDataAccessService(AppDbContext context, ILogger<PagesDataAccessService> logger) : base(context, logger)
        {
        }

        public override async Task<bool> AddValueAsync(PagesData obj)
        {
            try
            {
                dbContext.PagesDatas.Add(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> DeleteValueAsync(PagesData obj)
        {
            try
            {
                dbContext.PagesDatas.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<PagesData>> GetValueAsync()
        {
            return await dbContext.PagesDatas.ToListAsync();
        }

        public override async Task<bool> UpdateValueAsync(PagesData obj)
        {
            try
            {
                var Exist = dbContext.PagesDatas.FirstOrDefault(x => x.ID == obj.ID);
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
    }
}
