#nullable disable

using System;
using System.Runtime.Serialization;

namespace BunnyCdn
{
    public class EdgeRuleTrigger
    {
        public EdgeRuleTrigger() { }

        public EdgeRuleTrigger(EdgeRuleTriggerType type, MatchType patternMatchingType, string[] patternMatches)
        {
            Type = type;
            PatternMatchingType = patternMatchingType;
            PatternMatches = patternMatches;
        }

        [DataMember(Name = "Guid", EmitDefaultValue = false)]
        public Guid Guid { get; set; }

        public string Parameter1 { get; set; }

        public string[] PatternMatches { get; set; }

        public EdgeRuleTriggerType Type { get; set; }

        public MatchType PatternMatchingType { get; set; }
    }
}