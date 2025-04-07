using System.Security.Cryptography.X509Certificates;
using Application.Activities.Commands;
using Application.Activities.DTOs;

namespace Application.Activities.Validators;

public class CreateActivityValidator : BaseActivityValidator<CreateActivity.Command, CreateActivityDTO>
{
    public CreateActivityValidator() : base(x => x.ActivityDTO) 
    {
    }

}