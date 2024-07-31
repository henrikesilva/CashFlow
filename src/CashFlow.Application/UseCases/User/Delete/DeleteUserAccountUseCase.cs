﻿using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.User.Delete;
public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
{
    private readonly IUserWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfOfWork;
    private readonly ILoggedUser _loggedUser;

    public DeleteUserAccountUseCase(
        IUserWriteOnlyRepository repository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser)
    {
        _repository = repository;
        _unitOfOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }

    public async Task Execute()
    {
        var user = await _loggedUser.Get();

        await _repository.Delete(user);

        await _unitOfOfWork.Commit();
    }
}
