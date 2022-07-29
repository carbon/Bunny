#nullable disable

namespace BunnyCdn;

public sealed class EdgeRuleTrigger
{
    public EdgeRuleTrigger() { }

    public EdgeRuleTrigger(EdgeRuleTriggerType type, MatchType patternMatchingType, string[] patternMatches)
    {
        Type = type;
        PatternMatchingType = patternMatchingType;
        PatternMatches = patternMatches;
    }

    public Guid? Guid { get; init; }

    public string Parameter1 { get; init; }

    public string[] PatternMatches { get; init; }

    public EdgeRuleTriggerType Type { get; init; }

    public MatchType PatternMatchingType { get; init; }
}