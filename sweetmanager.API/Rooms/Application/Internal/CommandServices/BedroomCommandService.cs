using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Model.Repositories;
using sweetmanager.API.Rooms.Domain.Model.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Rooms.Application.Internal.CommandServices;

public class BedroomCommandService(
    IBedroomRepository bedroomRepository,
    IUnitOfWork unitOfWork) : IBedroomCommandService
{
    public async Task<Bedroom> Handle(CreateBedroomCommand command)
    {
        try
        {
            await bedroomRepository.AddAsync(new(command));

            await unitOfWork.CompleteAsync();

            return new(command);
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<Bedroom> Handle(UpdateBedroomCommand command)
    {
        try
        {
            var result = await bedroomRepository.FindByIdAsync(command.Id);

            if (result != null)
                bedroomRepository.Update(new Bedroom(command));

            await unitOfWork.CompleteAsync();

            return new(command);
        }
        catch (Exception e)
        {
            return new();
        }
    }
}