﻿using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommomTestUtilities.Repositories;
public class UserWriteReadOnlyRepositoryBuilder
{
    public static IUserWriteOnlyRepository Build()
    {
        var mock = new Mock<IUserWriteOnlyRepository>();

        return mock.Object;
    }
}
