using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.IAM.Infrastructure.Pipeline.Middleware.Attributes;
using sweetmanager.API.Rooms.Domain.Model.Queries;
using sweetmanager.API.Rooms.Domain.Services;
using sweetmanager.API.Rooms.Interfaces.REST.Resources;
using sweetmanager.API.Rooms.Interfaces.REST.Transform;

namespace sweetmanager.API.Rooms.Interfaces.REST;

[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class BookingsController(IBookingCommandService bookingCommandService,
                                IBookingQueryService bookingQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBooking([FromBody] CreateBookingResource resource)
    {
        try
        {
            var booking =
                await bookingCommandService.Handle(
                    CreateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));

            var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

            return Ok(bookingResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateBooking([FromBody] UpdateBookingResource resource)
    {
        try
        {
            var booking =
                await bookingCommandService.Handle(
                    UpdateBookingCommandFromResourceAssembler.ToCommandFromResource(resource));

            var bookingResource = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

            return Ok(bookingResource);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllBookings()
    {
        try
        {
            var bookings = await bookingQueryService.Handle(new GetAllBookingsQuery());

            var bookingResources = bookings.Select(BookingResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(bookingResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpGet("{bookingId:int}")]
    public async Task<IActionResult> GetBookingById(int bookingId)
    {
        try
        {
            var booking = await bookingQueryService.Handle(new GetBookingByIdQuery(bookingId));

            if (booking is null) return BadRequest();

            var bookingResources = BookingResourceFromEntityAssembler.ToResourceFromEntity(booking);

            return Ok(bookingResources);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}