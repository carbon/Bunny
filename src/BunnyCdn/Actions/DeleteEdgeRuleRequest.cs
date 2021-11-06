using System;

namespace BunnyCdn;

public sealed class DeleteEdgeRuleRequest
{
    public DeleteEdgeRuleRequest(long pullZoneId, Guid edgeRuleId)
    {
        PullZoneId = pullZoneId;
        EdgeRuleId = edgeRuleId;
    }

    public long PullZoneId { get; }

    public Guid EdgeRuleId { get; }
}