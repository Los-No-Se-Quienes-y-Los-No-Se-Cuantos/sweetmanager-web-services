using sweetmanager.API.IAM.Domain.Model.Aggregates.Work;
using sweetmanager.API.IAM.Domain.Model.Commands;
using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Worker;

namespace sweetmanager.API.IAM.Domain.Services.Users.Work;

public interface IWorkerCommandService
{
    Task<Worker?> Handle(SignUpWorkerCommand command);

    Task<dynamic?> Handle(SignInCommand command);
}