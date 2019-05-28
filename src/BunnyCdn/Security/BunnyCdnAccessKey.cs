using System;
using System.Threading.Tasks;

namespace BunnyCdn
{
    public sealed class BunnyCdnAccessKey : IBunnyCdnAccessKey
    {
        public BunnyCdnAccessKey(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public bool ShouldRenew => false;

        public Task RenewAsync() => Task.CompletedTask;

        public string Value { get; }
    }
}