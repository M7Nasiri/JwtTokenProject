using Common.Application;
using Common.Application.SecurityUtil;
using Domain.UserAgg;
using Domain.UserAgg.Repository;
using Domain.UserAgg.Services;


namespace Application.Users.Register;

internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
{
    private readonly IUserRepository _repository;
    private readonly IUserDomainService _domainService;

    public RegisterUserCommandHandler(IUserRepository repository, IUserDomainService domainService)
    {
        _repository = repository;
        _domainService = domainService;
    }

    public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var user = User.RegisterUser(request.PhoneNumber, Sha256Hasher.Hash(request.Password), _domainService);

        _repository.Add(user);
        await _repository.Save();
        return OperationResult.Success();
    }
}