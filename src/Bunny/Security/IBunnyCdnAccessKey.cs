namespace Bunny.Cdn;

public interface IBunnyCdnAccessKey
{
    bool ShouldRenew { get; }

    ValueTask RenewAsync();

    string Value { get; }
}

// This contract may be implemented to allow keys to be rotated in production