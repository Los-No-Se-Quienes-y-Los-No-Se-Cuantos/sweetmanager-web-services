using sweetmanager.API.IAM.Domain.Model.Aggregates;
using sweetmanager.API.IAM.Domain.Model.Entities;
using sweetmanager.API.IAM.Domain.Repositories;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using sweetmanager.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace sweetmanager.API.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserCredentialRepository(AppDbContext context) : BaseRepository<UserCredential>(context), IUserCredentialRepository
{
    public async Task<UserCredential?> FindByUserIdAsync(int userId)
    {
        Task<UserCredential?> queryAsync = new(() => 
        (
            from cc in Context.Set<UserCredential>().ToList()
            join u in Context.Set<User>().ToList() on cc.UserId equals u.Id
            where cc.UserId == u.Id
            select cc
        ).FirstOrDefault());
        
        queryAsync.Start();

        var result = await queryAsync;

        return result;
    }
} 