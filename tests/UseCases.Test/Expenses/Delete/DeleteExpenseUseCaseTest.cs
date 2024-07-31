using CashFlow.Application.UseCases.Expenses.Delete;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Repositories;
using CommomTestUtilities.Repositories.Expense;
using FluentAssertions;

namespace UseCases.Test.Expenses.Delete;
public class DeleteExpenseUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);
        var useCase = CreateUseCase(loggedUser, expense);

        //Act
        var act = async () => await useCase.Execute(expense.Id);

        //Assert
        await act.Should().NotThrowAsync();
    }

    [Fact]
    public async Task Error_Expense_Not_Found()
    {
        //Arrange
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);
        var useCase = CreateUseCase(loggedUser);

        //Act
        var act = async () => await useCase.Execute(id: 1000);
        var result = await act.Should().ThrowAsync<NotFoundException>();

        //Assert
        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EXPENSE_NOT_FOUND));
    }

    private DeleteExpenseUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var repositoryWriteOnly = ExpensesWriteOnlyRepositoryBuilder.Build();
        var repository = new ExpenseReadOnlyRepositoryBuilder().GetById(user, expense).Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new DeleteExpenseUseCase(repository, repositoryWriteOnly, unitOfWork, loggedUser);
    }
}
