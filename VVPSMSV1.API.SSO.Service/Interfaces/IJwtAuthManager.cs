﻿namespace VVPSMSV1.API.SSO.Service.Interfaces
{
    public interface IJwtAuthManager
    {
        Tuple<string, DateTime> GenerateToken(string value, DateTime now, Guid id);
        Tuple<string, DateTime> GenerateRefreshToken(DateTime now);
        bool ValidateToken(string token);
    }
}
