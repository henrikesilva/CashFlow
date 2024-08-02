﻿using CashFlow.Application.UseCases.Expenses.GetById;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;
using CommomTestUtilities.Entities;
using CommomTestUtilities.LoggedUser;
using CommomTestUtilities.Mapper;
using CommomTestUtilities.Repositories.Expense;
using FluentAssertions;

namespace UseCases.Test.Expenses.GetById;
public class GetExpenseByIdUseCaseTest
{
    [Fact]
    public async Task Success()
    {
        //Arrange
        var loggedUser = UserBuilder.Build();
        var expense = ExpenseBuilder.Build(loggedUser);

        var useCase = CreateUseCase(loggedUser, expense);

        //Act
        var result = await useCase.Execute(expense.Id);

        //Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(expense.Id);
        result.Title.Should().Be(expense.Title);
        result.Description.Should().Be(expense.Description);
        result.Date.Should().Be(expense.Date);
        result.Amount.Should().Be(expense.Amount);
        result.PaymentType.Should().Be((CashFlow.Communication.Enums.PaymentType)expense.PaymentType);
        result.Tags.Should().NotBeNullOrEmpty().And.BeEquivalentTo(expense.Tags.Select(tag => tag.Value));
    }

    [Fact]
    public async Task Error_Expense_Not_Found()
    {
        //Arrange
        var loggedUser = UserBuilder.Build();
        var useCase = CreateUseCase(loggedUser);

        //Act
        var act = async () => await useCase.Execute(id: 1000);

        //Assert
        var result = await act.Should().ThrowAsync<NotFoundException>();
        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EXPENSE_NOT_FOUND));
    }

    private GetExpenseByIdUseCase CreateUseCase(User user, Expense? expense = null)
    {
        var repository = new ExpenseReadOnlyRepositoryBuilder().GetById(user, expense).Build();
        var mapper = MapperBuilder.Build();
        var loggedUser = LoggedUserBuilder.Build(user);

        return new GetExpenseByIdUseCase(repository, mapper, loggedUser);
    }
}
