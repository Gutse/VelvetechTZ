using System;

namespace VelvetechTZ.Core.Authentication
{
    public interface IJwtTokenIssuer
    {
        (string Token, DateTime ExpirationTime) IssueToken(long userIdentityId, long userId);
        (string Token, DateTime ExpirationTime) IssueStartToken(long campaignId, long userId);
    }
}