using System.Threading.Tasks;

namespace BunnyCdn
{
    public interface IBunnyCdnAccessKey
    {
        bool ShouldRenew { get; }

        Task RenewAsync();

        string Value { get; }
    }
}

// This contract may be implemented to allow keys to be rotated in production