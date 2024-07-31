﻿using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommomTestUtilities.Repositories.User;
public class UserUpdateOnlyRepositoryBuilder
{
    public static IUserUpdateOnlyRepository Build(CashFlow.Domain.Entities.User user)
    {
        var mock = new Mock<IUserUpdateOnlyRepository>();

        mock.Setup(repository => repository.GetById(user.Id)).ReturnsAsync(user);

        return mock.Object;
    }
}
