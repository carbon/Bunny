namespace Bunny.Cdn;

public sealed class DeleteEdgeRuleRequest(long pullZoneId, Guid edgeRuleId)
{
    public long PullZoneId { get; } = pullZoneId;

    public Guid EdgeRuleId { get; } = edgeRuleId;
}