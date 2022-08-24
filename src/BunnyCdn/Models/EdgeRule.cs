namespace BunnyCdn;

public sealed class EdgeRule
{
    public string? Guid { get; set; }

    public string? ActionParameter1 { get; set; }

    public string? ActionParameter2 { get; set; }

    public EdgeRuleActionType ActionType { get; set; }

    public bool Enabled { get; set; }

    public string? Description { get; set; }

    public MatchType? TriggerMatchingType { get; set; }

    public EdgeRuleTrigger[]? Triggers { get; set; }
}