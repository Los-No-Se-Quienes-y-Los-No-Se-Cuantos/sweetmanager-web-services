using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Payments.Domain.Model.Queries;
using sweetmanager.API.Payments.Domain.Services;
using sweetmanager.API.Payments.Interfaces.REST.Resources;
using sweetmanager.API.Payments.Interfaces.REST.Transforms;

namespace sweetmanager.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentController(IPaymentCommandService commandService, IPaymentQueryService queryService)
    : ControllerBase
{


    [HttpPost]
    public async Task<IActionResult> CreatePayment([FromBody] CreatePaymentResource resource)
    {
        var command = CreatePaymentCommandFromResourceAssembler.ToCommandFromResource(resource);
        var payment = await commandService.Handle(command);
        return CreatedAtAction(nameof(GetPaymentById), new { paymentId = payment.Id }, payment);
    }
    
    private async Task<IActionResult> GetAllPayments()
    {
        var payments = await queryService.Handle(new GetAllPaymentsQuery());
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }
    
    private async Task<IActionResult> GetAllPaymentsByEmail(string email)
    {
        var payments = await queryService.Handle(new GetAllPaymentByEmailQuery(email));
        var paymentResources = payments.Select(PaymentResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(paymentResources);
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<PaymentResource>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllPaymentsFromQuery([FromQuery] string email)
    {
        if (string.IsNullOrEmpty(email)) return await GetAllPayments();
        return await GetAllPaymentsByEmail(email);
    }
    
    [HttpGet("{paymentId:int}")]
    [ProducesResponseType(typeof(PaymentResource), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetPaymentById(int paymentId)
    {
        var payment = await queryService.Handle(new GetPaymentByIdQuery(paymentId));
        if (payment is null) return BadRequest();
        var paymentResource = PaymentResourceFromEntityAssembler.ToResourceFromEntity(payment);
        return Ok(paymentResource);
    }
}