using CashFlow.Application.UseCases.User.ChangePassword;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommomTestUtilities.Cryptography;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Repositories.User;
using CommomTestUtilities.Requests;
using FluentAssertions;

namespace UseCases.Test.Users.ChangePassword;
public class ChangePasswordUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var user = UserBuilder.Build();
        var request = RequestChangePasswordJsonBuilder.Build();

        var useCase = CreateUseCase(user, request.Password);

        //Act
        var act = async () => await useCase.Execute(request);

        //Assert
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Error_NewPassword()
    {
        //Arrange
        var user = UserBuilder.Build();

        var request = RequestChangePasswordJsonBuilder.Build();
        request.NewPassword = string.Empty;

        var useCase = CreateUseCase(user, request.Password);

        //Act
        var act = async () => { await useCase.Execute(request); };

        //Assert
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(e => e.GetErrors().Count == 1 && e.GetErrors().Contains(ResourceErrorMessages.INVALID_PASSWORD));
    }

    [Fact]
    public async Task Error_Current_Password_Different()
    {
        //Arrange
        var user = UserBuilder.Build();
        var request = RequestChangePasswordJsonBuilder.Build();

        var useCase = CreateUseCase(user);

        //Act
        var act = async () => await useCase.Execute(request);

        //Assert
        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(e => e.GetErrors().Count == 1 && e.GetErrors().Contains(ResourceErrorMessages.PASSWORD_DIFFERENT_CURRENT_PASSWORD));
    }

    private ChangePasswordUseCase CreateUseCase(User user, string? password = null)
    {
        var unitOfWork = UnitOfWorkBuilder.Build();
        var userUpdateRepository = UserUpdateOnlyRepositoryBuilder.Build(user);
        var loggedUser = LoggedUserBuilder.Build(user);
        var passwordEncrypter = new PasswordEncrypterBuilder().Verify(password).Build();

        return new ChangePasswordUseCase(loggedUser, userUpdateRepository, unitOfWork, passwordEncrypter);
    }
}
