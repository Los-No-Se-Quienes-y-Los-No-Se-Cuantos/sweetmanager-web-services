using sweetmanager.API.Rooms.Domain.Model.Commands;
using sweetmanager.API.Rooms.Domain.Model.ValueObjects;

namespace sweetmanager.API.Rooms.Domain.Model.Aggregates;

public class Booking
{
    public int Id { get; }
    public int ClientId { get; private set; }
    public int BedroomId { get; private set; }
    public BookingDetail Detail { get; private set; }
    public EBookingStatus BookingStatus { get; private set; }

    public string DetailBooking => Detail.LengthOfStay();

    public Booking()
    {
        ClientId = 0;
        BedroomId = 0;
        Detail = new BookingDetail();
    }
    public Booking(int clientId, int bedroomId, DateTime startDate,
        DateTime finalDate, float totalPrice, string state)
    {
        ClientId = clientId;
        BedroomId = bedroomId;
        Detail = new BookingDetail(startDate, finalDate, totalPrice);

        if (state == "Reserved") BookingStatus = EBookingStatus.Reserved;
        else BookingStatus = EBookingStatus.Cancel;
    }
    public Booking(CreateBookingCommand command)
    {
        ClientId = command.ClientId;
        BedroomId = command.BedroomId;
        
        Detail = new BookingDetail(command.StartDate, command.FinalDate, command.TotalPrice);
        
        if (command.State == "Reserved") BookingStatus = EBookingStatus.Reserved;
        else BookingStatus = EBookingStatus.Cancel;
    }

    public Booking(UpdateBookingCommand command)
    {
        ClientId = command.ClientId;
    }
    
    public Booking(DeleteBookingCommand command)
    {
        Id = command.Id;
    }
}