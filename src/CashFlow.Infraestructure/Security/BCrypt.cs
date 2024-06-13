﻿using CashFlow.Domain.Security;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infraestructure.Security;
internal class BCrypt : IPasswordEncripter
{
    public string Encrypt(string password)
    {
        string passwordHash = BC.HashPassword(password);

        return passwordHash;
    }
}
