using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
using CashFlow.Domain.Entities;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Repositories.Expense;
using FluentAssertions;

namespace UseCases.Test.Expenses.Reports.Pdf;
public class GenerateExpenseReportPdfUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Collection(loggedUser);

        var useCase = CreateUseCase(loggedUser, expense);

        //Act
        var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Today));

        //Assert
        result.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public async Task Success_Empty() 
    {
        //Arrange
        var loggedUser = UserBuilder.Build();

        var useCase = CreateUseCase(loggedUser, new List<Expense>());

        //Act
        var result = await useCase.Execute(DateOnly.FromDateTime(DateTime.Today));

        //Assert
        result.Should().BeEmpty();
    }

    private GenerateExpenseReportPdfUseCase CreateUseCase(User user, List<Expense> expenses)
    {
        var repository = new ExpenseReadOnlyRepositoryBuilder().FilterByMonth(user, expenses).Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GenerateExpenseReportPdfUseCase(repository, loggedUser);
    }
}
