﻿namespace Creditcard.Service
{
    public interface ITokenService
    {
        string Authenticate(string username, string password);
    }
}