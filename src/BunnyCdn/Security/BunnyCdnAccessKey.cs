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

        public ValueTask RenewAsync()
        {
#if NETSTANDARD2_0
            return new ValueTask();
#else
            return ValueTask.CompletedTask;
#endif
        }
        public string Value { get; }
    }
}