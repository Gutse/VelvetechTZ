using System;

namespace VelvetechTZ.Core.Authentication
{
    public interface IJwtTokenIssuer
    {
        (string Token, DateTime ExpirationTime) IssueToken(long userIdentityId, long userId);
    }
}