using sweetmanager.API.Rooms.Domain.Model.Aggregates;
using sweetmanager.API.Rooms.Domain.Model.Commands;

namespace sweetmanager.API.Rooms.Domain.Model.Services;

public interface IBookingCommandService
{
    Task<Booking> Handle(CreateBookingCommand command);
    Task<Booking> Handle(UpdateBookingCommand command);
}