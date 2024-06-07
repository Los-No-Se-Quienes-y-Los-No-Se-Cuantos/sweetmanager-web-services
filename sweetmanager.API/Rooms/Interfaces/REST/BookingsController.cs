using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;
using sweetmanager.API.Rooms.Interfaces.REST.Transform;

namespace sweetmanager.API.Rooms.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BookingsController(IBookingCommandService bookingCommandService,
                                IBookingQueryService bookingQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingResource resource)
    {
        var booking = await bookingCommandService.Handle(CreateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));
        
        var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

        return Ok(bookingResource);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingResource resource)
    {
        var booking = await bookingCommandService.Handle(UpdateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));

        var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

        return Ok(bookingResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        var bookings = await bookingQueryService.Handle(new GetAllBookingsQuery());

        var bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);

        return Ok(bookingResources);
    }
    
    [HttpGet("{bookingId:int}")]
    public async Task<IActionResult> GetBookingById(int bookingId)
    {
        var booking = await bookingQueryService.Handle(new GetBookingByIdQuery(bookingId));

        if (booking is null) return BadRequest();

        var bookingResources = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

        return Ok(bookingResources);
    }
}