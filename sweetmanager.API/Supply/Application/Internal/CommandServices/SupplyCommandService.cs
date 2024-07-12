using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Commands;
using sweetmanager.API.Supply.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Services;

namespace sweetmanager.API.Supply.Application.Internal.CommandServices;

public class SupplyCommandService (ISupplyRepository supplyRepository, IUnitOfWork unitOfWork) 
    :ISupplyCommandService
{
    public async Task<Domain.Model.Aggregates.Supply> Handle(CreateSupplyCommand command)
    {
        var supplySource  = new Domain.Model.Aggregates.Supply(command);
        
        await supplyRepository.AddAsync(supplySource);
        
        await unitOfWork.CompleteAsync();
        
        return supplySource;
    }
}