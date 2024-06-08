namespace sweetmanager.API.Rooms.Domain.Model.ValueObjects;

public record BookingDetail(DateTime StartDate, DateTime FinalDate, float TotalPrice, float Discount)
{
    public BookingDetail() : this(DateTime.Now, DateTime.Now, 0, 0) { }

    public BookingDetail(DateTime startDate, DateTime finalDate, float totalPrice) : this(startDate, finalDate, totalPrice, 0) { }

    public string LengthOfStay() => StartDate + " - " + FinalDate + " | S/" + TotalPrice;
}