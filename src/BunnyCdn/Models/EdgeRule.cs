#nullable disable

using System.Runtime.Serialization;

namespace BunnyCdn
{
    public class EdgeRule
    {
        [DataMember(Name = "Guid", EmitDefaultValue = false)]
        public string Guid { get; set; }

        [DataMember(Name = "ActionParameter1", EmitDefaultValue = false)]
        public string ActionParameter1 { get; set; }

        [DataMember(Name = "ActionParameter2", EmitDefaultValue = false)]
        public string ActionParameter2 { get; set; }

        [DataMember(Name = "ActionType")]
        public EdgeRuleActionType ActionType { get; set; }

        [DataMember(Name = "Enabled")]
        public bool Enabled { get; set; }

        [DataMember(Name = "Description")]
        public string Description { get; set; }

        [DataMember(Name = "TriggerMatchingType")]
        public MatchType TriggerMatchingType { get; set; }

        [DataMember(Name = "Triggers")]
        public EdgeRuleTrigger[] Triggers { get; set; }
    }
}