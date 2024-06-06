using sweetmanager.API.Rooms.Domain.Model.Commands;

namespace sweetmanager.API.Rooms.Domain.Model.Aggregates;

public partial class Booking
{
    public int Id { get; }
    public int ClientId { get; private set; }
    public int BedroomId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime FinalDate { get; private set; }
    public float TotalPrice { get; private set; }
    public string State { get; private set; }

    public Booking()
    {
        ClientId = 0;
        BedroomId = 0;
        StartDate = DateTime.Now;
        FinalDate = DateTime.Now;
        TotalPrice = 0;
        State = string.Empty;
    }
    public Booking(int clientId, int bedroomId, DateTime startDate,
        DateTime finalDate, float totalPrice, string state)
    {
        ClientId = clientId;
        BedroomId = bedroomId;
        StartDate = startDate;
        FinalDate = finalDate;
        TotalPrice = totalPrice;
        State = state;
    }
    public Booking(CreateBookingCommand command)
    {
        ClientId = command.ClientId;
        BedroomId = command.BedroomId;
        StartDate = command.StartDate;
        FinalDate = command.FinalDate;
        TotalPrice = command.TotalPrice;
        State = command.State;
    }
}