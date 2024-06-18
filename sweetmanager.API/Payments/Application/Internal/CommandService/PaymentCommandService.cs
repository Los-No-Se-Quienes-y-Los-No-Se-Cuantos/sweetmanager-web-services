using sweetmanager.API.Payments.Application.Internal.OutboundServices.ACL;
using sweetmanager.API.Payments.Domain.Model.Aggregates;
using sweetmanager.API.Payments.Domain.Model.Command;
using sweetmanager.API.Payments.Domain.Repositories;
using sweetmanager.API.Payments.Domain.Services;
using sweetmanager.API.Shared.Domain.Repositories;

namespace sweetmanager.API.Payments.Application.Internal.CommandService;

public class PaymentCommandService(IPaymentRepository paymentRepository, IUnitOfWork unitOfWork, ExternalProfileService externalProfileService): IPaymentCommandService
{
    public async Task<Payment> Handle(CreatePaymentCommand command)
    {
        var profileId = await externalProfileService.FetchProfileByEmail(command.ProfileEmail);
        if (profileId == null)
        {
            throw new Exception("Profile not found");
        }
        var payment = new Payment(command, profileId.ProfileId);
        await paymentRepository.AddAsync(payment);
        await unitOfWork.CompleteAsync();
        return payment;
    }
}