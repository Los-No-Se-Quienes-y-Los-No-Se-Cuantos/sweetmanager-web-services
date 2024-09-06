using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Repositories;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Rooms.Application.Internal.CommandServices;

public class BookingCommandService(IBookingRepository bookingRepository,
                                   IUnitOfWork unitOfWork) : IBookingCommandService
{
    public async Task<Booking> Handle(CreateBookingCommand command)
    {
        try
        {
            await bookingRepository.AddAsync(new(command));

            await unitOfWork.CompleteAsync();

            return new(command);
        }
        catch (Exception)
        {
            return new();
        }
    }

    public async Task<Booking> Handle(UpdateBookingCommand command)
    {
        try
        {
            var result = await bookingRepository.FindByIdAsync(command.Id);

            if (result != null)
                bookingRepository.Update(new (command));

            await unitOfWork.CompleteAsync();

            return new(command);
        }
        catch (Exception e)
        {
            return new();
        }
    }
    
    public async Task<Booking> Handle(DeleteBookingCommand command)
    {
        try
        {
            var result = await bookingRepository.FindByIdAsync(command.Id);

            if (result != null)
                bookingRepository.Remove(result);

            await unitOfWork.CompleteAsync();

            return new(command);
        }
        catch (Exception)
        {
            return new();
        }
    }
}