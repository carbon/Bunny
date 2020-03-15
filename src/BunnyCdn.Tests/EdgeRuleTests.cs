
using System.Text.Json;

using Xunit;

namespace BunnyCdn.Tests
{
    public class EdgeRuleTests
    {
        [Fact]
        public void Serialize()
        {
            _ = new BunnyCdnClient("abc");

            var rule = new EdgeRule
            {
                ActionType = EdgeRuleActionType.BlockRequest,
                Description = "RULE NAME",
                Triggers = new[]
                {
                    new EdgeRuleTrigger
                    {
                       Parameter1 = "abc",
                       PatternMatches = new[] { "1", "2", "3" },
                       PatternMatchingType = MatchType.Any,
                       Type = EdgeRuleTriggerType.RequestUrl
                    }
                }
            };

            Assert.Equal(@"{
  ""ActionType"": 4,
  ""Enabled"": false,
  ""Description"": ""RULE NAME"",
  ""Triggers"": [
    {
      ""Parameter1"": ""abc"",
      ""PatternMatches"": [
        ""1"",
        ""2"",
        ""3""
      ],
      ""Type"": 0,
      ""PatternMatchingType"": 0
    }
  ]
}", JsonSerializer.Serialize(rule, new JsonSerializerOptions { WriteIndented = true, IgnoreNullValues = true }));
        }

    }
}