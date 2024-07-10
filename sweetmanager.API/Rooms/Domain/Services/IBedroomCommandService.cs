using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Commands;

namespace sweetmanager.API.Rooms.Domain.Services;

public interface IBedroomCommandService
{
    Task<Bedroom?> Handle(CreateBedroomCommand command);
    
    Task<Bedroom?> Handle(UpdateBedroomCommand command);
}