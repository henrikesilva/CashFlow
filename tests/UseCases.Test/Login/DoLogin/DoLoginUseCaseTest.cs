﻿using CashFlow.Application.UseCases.Login;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommomTestUtilities.Cryptography;
using CommomTestUtilities.Entities;
using CommomTestUtilities.Repositories.User;
using CommomTestUtilities.Requests;
using CommomTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Login.DoLogin;
public class DoLoginUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var user = UserBuilder.Build();

        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;

        var useCase = CreateUseCase(user, request.Password);

        //Act
        var result = await useCase.Execute(request);

        //Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(user.Name);
        result.Token.Should().NotBeNullOrWhiteSpace();
    }

    [Fact]
    public async Task Error_User_Not_Found()
    {
        //Arrange
        var user = UserBuilder.Build();

        var request = RequestLoginJsonBuilder.Build();

        var useCase = CreateUseCase(user, request.Password);

        //Act
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<InvalidLoginException>();

        //Assert
        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID));
    }

    [Fact]
    public async Task Error_Password_Not_Match()
    {
        //Arrange
        var user = UserBuilder.Build();

        var request = RequestLoginJsonBuilder.Build();
        request.Email = user.Email;

        var useCase = CreateUseCase(user);

        //Act
        var act = async () => await useCase.Execute(request);
        var result = await act.Should().ThrowAsync<InvalidLoginException>();

        //Assert
        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_OR_PASSWORD_INVALID));
    }

    private DoLoginUseCase CreateUseCase(User user, string? password = null)
    {
        var passwordEncripter = new PasswordEncrypterBuilder().Verify(password).Build();
        var tokenGenerator = JwtTokenGeneratorBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

        return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);
    }
}
