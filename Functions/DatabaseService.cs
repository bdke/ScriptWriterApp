using Microsoft.EntityFrameworkCore;
using ScriptWriterApp.Data;

namespace ScriptWriterApp.Functions
{
    class DatabaseService
    {
        private AppDbContext dbContext;

        public DatabaseService(AppDbContext dbContext)        
        {
            this.dbContext = dbContext;
        }   

        public async Task<List<ChangeHistory>> GetChangeHistoriesAsync()
        {
            return await dbContext.ChangeHistories.ToListAsync();
        }

        public async Task<ChangeHistory> AddChangeHistoryAsync(ChangeHistory changeHistory)
        {
            try
            {
                dbContext.ChangeHistories.Add(changeHistory);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return changeHistory;
        }

        public async Task DeleteChangeHistoryAsync(ChangeHistory changeHistory)
        {
            try
            {
                dbContext.ChangeHistories.Remove(changeHistory);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
