using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Rooms.Application.Internal.CommandServices;

public class BedroomCommandService(
    IBedroomRepository bedroomRepository,
    IUnitOfWork unitOfWork) : IBedroomCommandService
{
    public async Task<Bedroom?> Handle(CreateBedroomCommand command)
    {
        try
        {
            var result = new Bedroom(command);
            
            await bedroomRepository.AddAsync(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }

    public async Task<Bedroom?> Handle(UpdateBedroomCommand command)
    {
        try
        {
            var result = await bedroomRepository.FindByIdAsync(command.Id);

            if (result == null)
                throw new Exception($"Bedroom with id {command.Id} not found");

            result.Update(command);
            
            bedroomRepository.Update(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }
    
    public async Task<Bedroom?> Handle(UpdateBedroomStateCommand command)
    {
        try
        {
            var result = await bedroomRepository.FindByIdAsync(command.Id);

            if (result == null)
                throw new Exception($"Bedroom with id {command.Id} not found");

            result.UpdateState(command.BedroomState);
            
            bedroomRepository.Update(result);

            await unitOfWork.CompleteAsync();

            return result;
        }
        catch (Exception)
        {
            return null;
        }
    }
}