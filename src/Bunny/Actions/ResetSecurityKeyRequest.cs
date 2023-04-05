﻿namespace Bunny.Cdn;

public sealed class ResetSecurityKeyRequest
{
    public ResetSecurityKeyRequest(long pullZoneId)
    {
        Id = pullZoneId;
    }

    public long Id { get; }
}
