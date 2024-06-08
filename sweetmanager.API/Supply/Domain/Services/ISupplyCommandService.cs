using sweetmanager.API.Supply.Domain.Model.Aggregates;
using sweetmanager.API.Supply.Domain.Model.Commands;

namespace sweetmanager.API.Supply.Domain.Services;

public interface ISupplyCommandService
{
    Task<Model.Aggregates.Supply> Handle(CreateSupplyCommand command);
}