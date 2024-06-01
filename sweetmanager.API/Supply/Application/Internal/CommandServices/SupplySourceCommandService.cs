using sweetmanager.API.Shared.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Commands;
using sweetmanager.API.Supply.Domain.Repositories;
using sweetmanager.API.Supply.Domain.Services;

namespace sweetmanager.API.Supply.Application.Internal.CommandServices;

public class SupplySourceCommandService (ISupplySourceRepository supplySourceRepository, IUnitOfWork unitOfWork) 
    :ISupplySourceCommandService
{
    public async Task<SupplySource> Handle(CreateSupplySourceCommand command)
    {
        var supplySource  = new SupplySource(command);
        await supplySourceRepository.AddAsync(new SupplySource(command));
        await unitOfWork.CompleteAsync();
        return supplySource;
    }
}