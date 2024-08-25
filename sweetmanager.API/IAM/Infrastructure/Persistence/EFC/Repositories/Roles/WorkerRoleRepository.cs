using Microsoft.EntityFrameworkCore;
using sweetmanager.API.IAM.Domain.Model.Entities.Roles.WorkerAreas;
using sweetmanager.API.IAM.Domain.Model.ValueObjects;
using sweetmanager.API.IAM.Domain.Repositories.Roles;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories.Roles;

public class WorkerRoleRepository(AppDbContext context) : BaseRepository<WorkerRole>(context), IWorkerRoleRepository
{
    public async Task<WorkerRole?> FindByNameAsync(EWorkerRoles name) =>
        await Context.Set<WorkerRole>().FirstOrDefaultAsync(r => r.Role == name);

    public async Task<bool> ExistByNameAsync(EWorkerRoles name) =>
        await Context.Set<WorkerRole>().AnyAsync(r => r.Role == name);

    public async Task<IEnumerable<WorkerRole>> ValidateSupervisionAreasByAreas(ICollection<string> supervisionAreas)
    {
        Task<IEnumerable<WorkerRole>> queryAsync = new(() =>
        (
            from cc in Context.Set<WorkerRole>().ToList()
            where supervisionAreas.Contains(cc.Role.ToString())
            select cc
        ));
        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }

    public async Task<int> FindByWorkerRoleName(string role)
    =>  await Task.Run(() =>
            (
            from wr in Context.Set<WorkerRole>().ToList()
            where wr.Role.ToString().Equals(role)
            select wr.Id
            ).FirstOrDefault());
    
    
    // await Context.Set<WorkerRole>().Where(wr => supervisionAreas.Contains(wr.Role.ToString())).ToListAsync();
}