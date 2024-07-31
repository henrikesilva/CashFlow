using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommomTestUtilities.Repositories.Expense;
public class ExpenseUpdateOnlyRepositoryBuilder
{
    private readonly Mock<IExpensesUpdateOnlyRepository> _repository;

    public ExpenseUpdateOnlyRepositoryBuilder()
    {
        _repository = new Mock<IExpensesUpdateOnlyRepository>();
    }

    public ExpenseUpdateOnlyRepositoryBuilder GetById(CashFlow.Domain.Entities.User user, CashFlow.Domain.Entities.Expense? expense)
    {
        if (expense is not null)
            _repository.Setup(repository => repository.GetById(user, expense.Id)).ReturnsAsync(expense);

        return this;
    }

    public IExpensesUpdateOnlyRepository Build() => _repository.Object;
}
