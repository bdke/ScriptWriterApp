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

        public async Task ClearNullDataAsync(List<PagesData> pages)
        {
            foreach (PagesData page in pages)
            {
                if (page.FoldersDataID == null)
                {
                    await DeleteValueAsync(page);
                }
            }
        }
    }

    public class FoldersDataAccessService : DatabaseAccessService<FoldersData>
    {
        public FoldersDataAccessService(AppDbContext context, ILogger<PagesDataAccessService> logger) : base(context, logger)
        {
        }

        public override async Task<bool> AddValueAsync(FoldersData obj)
        {
            try
            {
                dbContext.FolderDatas.Add(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> DeleteValueAsync(FoldersData obj)
        {
            try
            {
                dbContext.FolderDatas.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<FoldersData>> GetValueAsync()
        {
            return await dbContext.FolderDatas.ToListAsync();
        }

        public override async Task<bool> UpdateValueAsync(FoldersData obj)
        {
            try
            {
                var Exist = dbContext.FolderDatas.FirstOrDefault(x => x.ID == obj.ID);
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

        public async Task ClearNullDataAsync(List<FoldersData> folders)
        {
            foreach (FoldersData folder in folders)
            {
                if (folder.FoldersDataID == null && folder.ID > 1)
                {
                    await DeleteValueAsync(folder);
                }
            }
        }
    }

    public class UsersDataAccessService : DatabaseAccessService<UsersData>
    {
        public UsersDataAccessService(AppDbContext context, ILogger<UsersDataAccessService> logger) : base(context, logger)
        {
        }

        public override async Task<bool> AddValueAsync(UsersData obj)
        {
            try
            {
                dbContext.UsersDatas.Add(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<bool> DeleteValueAsync(UsersData obj)
        {
            try
            {
                dbContext.UsersDatas.Remove(obj);
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override async Task<List<UsersData>> GetValueAsync()
        {
            return await dbContext.UsersDatas.ToListAsync();
        }

        public override async Task<bool> UpdateValueAsync(UsersData obj)
        {
            try
            {
                var Exist = dbContext.UsersDatas.FirstOrDefault(x => x.ID == obj.ID);
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
