using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using sweetmanager.API.Payments.Domain.Services;

namespace sweetmanager.API.Payments.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class PaymentController(IPaymentCommandService commandService, IPaymentQueryService queryService)
    : ControllerBase
{
}