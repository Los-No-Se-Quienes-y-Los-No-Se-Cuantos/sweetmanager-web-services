using Microsoft.EntityFrameworkCore;
using sweetmanager.API.Inspection.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Task = sweetmanager.API.Inspection.Domain.Model.Aggregates.Assignments.Task;

namespace sweetmanager.API.Inspection.Infrastructure.Persistence.EFC.Repositories;

public class TaskRepository(AppDbContext appDbContext): BaseRepository<Task>(appDbContext), ITaskRepository
{
    public async Task<IEnumerable<Task>> FindTaskByWorkerIdAsync(int workerId)
    {
        return await Context.Set<Task>().Where(t => t.WorkerId == workerId).ToListAsync();
    }
}
