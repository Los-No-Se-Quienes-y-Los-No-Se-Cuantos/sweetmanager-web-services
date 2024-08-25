using sweetmanager.API.IAM.Domain.Model.Commands.Authentication.Worker;
using sweetmanager.API.IAM.Interfaces.REST.Resources.Authentication.Work;

namespace sweetmanager.API.IAM.Interfaces.REST.Transform.Work;

public static class SignUpWorkerCommandFromResourceAssembler
{
    public static SignUpWorkerCommand ToCommandFromResource(SignUpWorkerResource resource)
    {
        return new(resource.UserName, resource.Email, resource.Password, resource.PhoneNumber, resource.Surname,
            resource.Name, resource.WorkArea, resource.ActiveAccount);
    }
}