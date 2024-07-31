using CashFlow.Application.UseCases.User.Delete;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Repositories;
using FluentAssertions;

namespace UseCases.Test.Users.Delete;
public class DeleteUserAccountUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var user = UserBuilder.Build();
        var useCase = CreateUseCase(user);

        //Act
        var act = async () => await useCase.Execute();

        //Assert
        await act.Should().NotThrowAsync();
    }

    private DeleteUserAccountUseCase CreateUseCase(User user)
    {
        var repository = UserWriteReadOnlyRepositoryBuilder.Build();
        var loggeduser = LoggedUserBuilder.Build(user);
        var unitOfWork = UnitOfWorkBuilder.Build();

        return new DeleteUserAccountUseCase(repository, unitOfWork, loggeduser);
    }
}
