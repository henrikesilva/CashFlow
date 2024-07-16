using CashFlow.Domain.Repositories.Expenses;
using Moq;

namespace CommomTestUtilities.Repositories.Expense;
public class ExpenseReadOnlyRepositoryBuilder
{
    private readonly Mock<IExpensesReadOnlyRepository> _repository;

    public ExpenseReadOnlyRepositoryBuilder()
    {
        _repository = new Mock<IExpensesReadOnlyRepository>();
    }

    public ExpenseReadOnlyRepositoryBuilder GetAll(CashFlow.Domain.Entities.User user, List<CashFlow.Domain.Entities.Expense> expenses)
    {
        _repository.Setup(repository => repository.GetAll(user)).ReturnsAsync(expenses);

        return this;
    }

    public IExpensesReadOnlyRepository Build() => _repository.Object;
}
